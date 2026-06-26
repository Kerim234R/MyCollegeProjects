using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.Sqlite; // Используем новый пакет от Microsoft

namespace LibraryDataBase
{
    public partial class Form1 : Form // Примечание: если ты уже перенес это в FormBDBooks, поменяй имя класса здесь
    {
        public Form1()
        {
            InitializeComponent();

            initializeDB();   // Настраиваем колонки таблицы
            LoadBooksData();  // Сразу загружаем данные из SQL при старте
            SetupToolTips();  // Настраиваем подсказки для кнопок
        }

        // 1. НАСТРОЙКА ТАБЛИЦЫ (DataGridView)
        private void initializeDB()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("InvNumber", "Инв. номер");
            dataGridView1.Columns.Add("Title", "Название");
            dataGridView1.Columns.Add("Author", "Автор");
            dataGridView1.Columns.Add("Year", "Год");
            dataGridView1.Columns.Add("Publisher", "Издательство");
            dataGridView1.Columns.Add("Genre", "Жанр");
            dataGridView1.Columns.Add("Location", "Место хранения");
            dataGridView1.Columns.Add("Quantity", "Кол-во");
            dataGridView1.Columns.Add("Available", "Доступно");

            dataGridView1.Columns["Year"].Width = 60;
            dataGridView1.Columns["Quantity"].Width = 70;
            dataGridView1.Columns["Available"].Width = 80;
            dataGridView1.Columns["Title"].Width = 243;
            dataGridView1.Columns["Location"].Width = 150;

            dataGridView1.Columns["InvNumber"].ReadOnly = true; // Инв. номер менять нельзя!
        }

        // 2. ЗАГРУЗКА ДАННЫХ ИЗ SQL В ТАБЛИЦУ (Отображение)
        private void LoadBooksData()
        {
            dataGridView1.Rows.Clear();

            using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();

                // Если фильтр пустой - берем все книги, если нет - ищем конкретный инвентарный номер
                string query = "SELECT * FROM Books";
                if (!string.IsNullOrEmpty(DatabaseHelper.SearchFilter))
                {
                    query += " WHERE InvNumber = @filter";
                }

                using (var cmd = new SqliteCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(DatabaseHelper.SearchFilter))
                    {
                        cmd.Parameters.AddWithValue("@filter", DatabaseHelper.SearchFilter);
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(
                                reader["InvNumber"].ToString(),
                                reader["Title"].ToString(),
                                reader["Author"].ToString(),
                                reader["Year"].ToString(),
                                reader["Publisher"].ToString(),
                                reader["Genre"].ToString(),
                                reader["Location"].ToString(),
                                reader["Quantity"].ToString(),
                                reader["Available"].ToString()
                            );
                        }
                    }
                }
            }
        }

        // 3. КНОПКА: ДОБАВИТЬ КНИГУ (С автосохранением в базу)
        private void buttonAddbook_Click(object sender, EventArgs e)
        {
            // Проверяем самые важные поля на пустоту
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Заполните хотя бы Инв. номер и Название книги!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();

                    // SQL-запрос добавления новой строки. Знаки @ — это параметры (защита от багов и кавычек)
                    string insertQuery = @"
                        INSERT INTO Books (InvNumber, Title, Author, Year, Publisher, Genre, Location, Quantity, Available) 
                        VALUES (@Inv, @Title, @Author, @Year, @Pub, @Genre, @Loc, @Qty, @Avail);";

                    using (var cmd = new SqliteCommand(insertQuery, conn))
                    {
                        // Привязываем значения из твоих текст-боксов к параметрам запроса
                        cmd.Parameters.AddWithValue("@Inv", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Title", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@Author", textBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@Year", dateTimePicker1.Value.ToString("yyyy")); // Извлекаем только год
                        cmd.Parameters.AddWithValue("@Pub", textBox4.Text.Trim());
                        cmd.Parameters.AddWithValue("@Genre", textBox5.Text.Trim());
                        cmd.Parameters.AddWithValue("@Loc", textBox6.Text.Trim());
                        cmd.Parameters.AddWithValue("@Qty", (int)numericUpDown1.Value);
                        cmd.Parameters.AddWithValue("@Avail", (int)numericUpDown2.Value);

                        cmd.ExecuteNonQuery(); // Выполняем команду записи в файл БД
                    }
                }

                // Данные уже автоматически сохранились в файле library.db!
                LoadBooksData();    // Перезагружаем таблицу, чтобы увидеть новую книгу
                buttonChist_Click(null, null); // Очищаем поля ввода автоматически
            }
            catch (SqliteException ex) when (ex.SqliteErrorCode == 19) // Код 19 в SQLite — это нарушение уникальности PRIMARY KEY
            {
                MessageBox.Show("Книга с таким инвентарным номером уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении в SQL: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 4. КНОПКА: УДАЛИТЬ ОДНУ ВЫДЕЛЕННУЮ КНИГУ
        private void buttonDeleteOne_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Берем инвентарный номер из первой ячейки выделенной пользователем строки
                string invNum = dataGridView1.SelectedRows[0].Cells["InvNumber"].Value.ToString();

                var confirmResult = MessageBox.Show($"Вы уверены, что хотите удалить книгу с инв. номером {invNum}?",
                                                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                        {
                            conn.Open();
                            string deleteQuery = "DELETE FROM Books WHERE InvNumber = @Inv"; // SQL-запрос удаления

                            using (var cmd = new SqliteCommand(deleteQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@Inv", invNum);
                                cmd.ExecuteNonQuery(); // Удаляем из базы данных
                            }
                        }
                        LoadBooksData(); // Сразу обновляем таблицу на экране (эффект автосохранения)
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите всю строку в таблице (кликните слева от строки), которую хотите удалить!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 5. КНОПКА: ОЧИСТИТЬ ВСЕ СТРОКИ БАЗЫ ДАННЫХ (Полная очистка таблицы)
        private void buttonDelAll_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("ВНИМАНИЕ! Вы уверены, что хотите ПОЛНОСТЬЮ очистить базу данных книг? Это действие необратимо.",
                                                "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                    {
                        conn.Open();
                        string truncateQuery = "DELETE FROM Books"; // Удаляет абсолютно все записи из таблицы

                        using (var cmd = new SqliteCommand(truncateQuery, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadBooksData(); // Обновляем пустую таблицу на экране
                    MessageBox.Show("База данных книг успешно очищена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при очистке БД: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 6. КНОПКА: ПОИСК КНИГ (Умная фильтрация средствами SQL)
        private void buttonFind_Click(object sender, EventArgs e)
        {
            string searchTxt = textBoxFind.Text.Trim();

            if (string.IsNullOrEmpty(searchTxt))
            {
                LoadBooksData(); // Если поле поиска пустое, просто показываем все книги
                return;
            }

            dataGridView1.Rows.Clear();

            try
            {
                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();
                    // Оператор LIKE и знаки % позволяют искать по части слова (например, ввел "Пушк" — найдет "Пушкин")
                    string searchQuery = "SELECT * FROM Books WHERE Title LIKE @Search OR Author LIKE @Search";

                    using (var cmd = new SqliteCommand(searchQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Search", "%" + searchTxt + "%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataGridView1.Rows.Add(
                                    reader["InvNumber"].ToString(),
                                    reader["Title"].ToString(),
                                    reader["Author"].ToString(),
                                    reader["Year"].ToString(),
                                    reader["Publisher"].ToString(),
                                    reader["Genre"].ToString(),
                                    reader["Location"].ToString(),
                                    reader["Quantity"].ToString(),
                                    reader["Available"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 7. КНОПКА: СБРОС ФИЛЬТРА ПОИСКА
        private void button_clearFindFilter_Click(object sender, EventArgs e)
        {
            textBoxFind.Clear();
            LoadBooksData(); // Просто загружаем все данные обратно
        }

        // 8. КНОПКА: ОЧИСТИТЬ ПОЛЯ ВВОДА
        private void buttonChist_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear();
            textBox4.Clear(); textBox5.Clear(); textBox6.Clear();
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            dateTimePicker1.Value = DateTime.Now;
        }

        // 9. КНОПКА: ОЧИСТИТЬ ПОЛЕ ПОИСКА (Текстовое)
        private void button_clearFindPole_Click(object sender, EventArgs e)
        {
            textBoxFind.Clear();
        }

        private void SetupToolTips()
        {
            var tips = new Dictionary<Control, string> {
                // {label19, "" }, - макет

                {buttonFind, "Найти данные по заданному в поле поиска названию\nВнимание - сохраните БД перед сбросом поиска"},
                {buttonDeleteOne, "Удалить одну строку данных из БД\nПеред этим выберите полную строку в таблице"},
                {buttonAddbook, "Добавить книгу в БД"},
                {button_clearFindFilter, "Очистить фильтр поиска\nПокажет обратно все данные в таблице\nВнимание - сохраните БД перед сбросом поиска"},
                {buttonChist, "Очистить все поля для ввода данных в БД"},
                {buttonDelAll, "Удалить все строки в БД"},
                {button_clearFindPole, "Очистить поле поиска"},
                {textBox1, "Введите инвентарный номер книги"},
                {textBox2, "Введите название книги"},
                {textBox3, "Введите автора книги"},
                {textBox4, "Введите название издательства книги"},
                {textBox5, "Введите жанр/жанры книги"},
                {textBox6, "Введите местонахождение книги в библиотеке"},
                {textBoxFind, "Введите название или автора книги"},
                {dateTimePicker1, "Введите год издания книги"},
                {numericUpDown1, "Введите количество книг в библиотеке" },
                {numericUpDown2, "Введите доступное для выдачи количество книг в библиотеке" }
            };

            foreach (var tip in tips)
            {
                toolTip1.SetToolTip(tip.Key, tip.Value);
            }
        }

        // Автосохранение при изменении данных в строчках таблицы
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Проверяем, что изменилась реальная строка, а не заголовок таблицы
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];

                // Получаем инвентарный номер строки (по нему будем искать книгу в базе)
                string invNumber = row.Cells["InvNumber"].Value?.ToString();

                // Если инв. номера нет, значит это пустая строка для добавления, игнорируем её
                if (string.IsNullOrEmpty(invNumber)) return;

                try
                {
                    using (var conn = new Microsoft.Data.Sqlite.SqliteConnection(DatabaseHelper.ConnectionString))
                    {
                        conn.Open();

                        // SQL-запрос UPDATE: обновляет все поля у книги с конкретным инвентарным номером
                        string updateQuery = @"
                        UPDATE Books 
                        SET Title = @Title, 
                            Author = @Author, 
                            Year = @Year, 
                            Publisher = @Publisher, 
                            Genre = @Genre, 
                            Location = @Location, 
                            Quantity = @Qty, 
                            Available = @Avail
                        WHERE InvNumber = @Inv;";

                        using (var cmd = new Microsoft.Data.Sqlite.SqliteCommand(updateQuery, conn))
                        {
                            // Собираем текущие (новые) значения прямо из строчки таблицы на экране
                            cmd.Parameters.AddWithValue("@Inv", invNumber);
                            cmd.Parameters.AddWithValue("@Title", row.Cells["Title"].Value?.ToString() ?? "");
                            cmd.Parameters.AddWithValue("@Author", row.Cells["Author"].Value?.ToString() ?? "");
                            cmd.Parameters.AddWithValue("@Year", row.Cells["Year"].Value?.ToString() ?? "");
                            cmd.Parameters.AddWithValue("@Publisher", row.Cells["Publisher"].Value?.ToString() ?? "");
                            cmd.Parameters.AddWithValue("@Genre", row.Cells["Genre"].Value?.ToString() ?? "");
                            cmd.Parameters.AddWithValue("@Location", row.Cells["Location"].Value?.ToString() ?? "");

                            // Для чисел проверяем, чтобы не было ошибок конвертации
                            int qty = int.TryParse(row.Cells["Quantity"].Value?.ToString(), out int q) ? q : 1;
                            int avail = int.TryParse(row.Cells["Available"].Value?.ToString(), out int a) ? a : 1;
                            cmd.Parameters.AddWithValue("@Qty", qty);
                            cmd.Parameters.AddWithValue("@Avail", avail);

                            cmd.ExecuteNonQuery(); // Сохраняем изменения в файл базы данных
                        }
                    }
                    // Подсветим статусную строку или просто тихо сохраним (без вывода MessageBox, чтобы не бесить юзера)
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка автосохранения при изменении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
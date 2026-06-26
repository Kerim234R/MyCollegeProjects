using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Data.Sqlite;

namespace LibraryDataBase
{
    public partial class FormUchetKnig : Form
    {
        public FormUchetKnig()
        {
            InitializeComponent();
            LoadIssuanceData();

            this.FormClosing += (s, args) => Application.Exit();
            SetupToolTips();
        }

        private void LoadIssuanceData()
        {
            dataGridView1.Rows.Clear();

            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("InvChitBilet", "№ Билета");
                dataGridView1.Columns.Add("InvNumber", "Инв. Номер книги");
                dataGridView1.Columns.Add("IssueDate", "Дата выдачи");
                dataGridView1.Columns.Add("ReturnDate", "План. возврата");
                dataGridView1.Columns.Add("Status", "Статус");

                // Скрытая колонка для хранения уникального ID записи из БД
                dataGridView1.Columns.Add("Id", "ID");
                dataGridView1.Columns["Id"].Visible = false;
            }

            using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                string query = "SELECT Id, InvChitBilet, InvNumber, IssueDate, ReturnDate, Status FROM Issuance WHERE Status != 'Возвращено'";

                using (var cmd = new SqliteCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string dbStatus = reader["Status"].ToString();
                            string returnDateStr = reader["ReturnDate"].ToString();

                            // Логика статуса «Задерживается»
                            if (dbStatus == "Выдано" && DateTime.TryParse(returnDateStr, out DateTime planReturnDate))
                            {
                                if (planReturnDate.Date < DateTime.Today)
                                {
                                    dbStatus = "Задерживается";
                                }
                            }

                            dataGridView1.Rows.Add(
                                reader["InvChitBilet"].ToString(),
                                reader["InvNumber"].ToString(),
                                reader["IssueDate"].ToString(),
                                returnDateStr,
                                dbStatus,
                                reader["Id"].ToString()
                            );
                        }
                    }
                }
            }
        }

        private void buttonGiveBook_Click(object sender, EventArgs e)
        {
            string invNum = textBox1.Text.Trim();
            string chitBilet = textBox2.Text.Trim();
            string issueDate = DateTime.Now.ToString("yyyy-MM-dd");
            string returnDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            if (string.IsNullOrEmpty(invNum) || string.IsNullOrEmpty(chitBilet))
            {
                MessageBox.Show("Заполните все поля (Инв. номер книги и № билета)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();

                    // 1. ПРОВЕРКА: Существует ли ученик с таким номером билета?
                    string checkReaderQuery = "SELECT COUNT(*) FROM Readers WHERE InvChitBilet = @ChitBilet;";
                    using (var cmdCheckReader = new SqliteCommand(checkReaderQuery, conn))
                    {
                        cmdCheckReader.Parameters.AddWithValue("@ChitBilet", chitBilet);
                        long readerCount = (long)cmdCheckReader.ExecuteScalar();

                        if (readerCount == 0)
                        {
                            MessageBox.Show("Читатель с таким номером билета не найден в базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Останавливаем выдачу
                        }
                    }

                    // 2. ПРОВЕРКА: Существует ли книга и есть ли она в наличии?
                    string checkBookQuery = "SELECT Available FROM Books WHERE InvNumber = @InvNum;";
                    using (var cmdCheckBook = new SqliteCommand(checkBookQuery, conn))
                    {
                        cmdCheckBook.Parameters.AddWithValue("@InvNum", invNum);
                        var result = cmdCheckBook.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Книга с таким инвентарным номером не найдена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        int available = Convert.ToInt32(result);
                        if (available <= 0)
                        {
                            MessageBox.Show("Данной книги сейчас нет в наличии (все экземпляры выданы)!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // 3. ОФОРМЛЕНИЕ ВЫДАЧИ
                    string insertQuery = "INSERT INTO Issuance (InvChitBilet, InvNumber, IssueDate, ReturnDate, Status) VALUES (@ChitBilet, @InvNum, @Issue, @Return, 'Выдано');";
                    using (var cmdInsert = new SqliteCommand(insertQuery, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@ChitBilet", chitBilet);
                        cmdInsert.Parameters.AddWithValue("@InvNum", invNum);
                        cmdInsert.Parameters.AddWithValue("@Issue", issueDate);
                        cmdInsert.Parameters.AddWithValue("@Return", returnDate);
                        cmdInsert.ExecuteNonQuery();
                    }

                    // 4. УМЕНЬШАЕМ КОЛИЧЕСТВО КНИГ В НАЛИЧИИ
                    string updateBookQuery = "UPDATE Books SET Available = Available - 1 WHERE InvNumber = @InvNum;";
                    using (var cmdUpdate = new SqliteCommand(updateBookQuery, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@InvNum", invNum);
                        cmdUpdate.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Книга успешно выдана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadIssuanceData();

                // Очищаем поля ввода
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выдаче книги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonTakeBack_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {
                MessageBox.Show("Выберите строку с выдачей, которую хотите вернуть!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем ID записи из скрытой колонки
            string recordId = dataGridView1.CurrentRow.Cells[5].Value?.ToString();
            string invNumber = dataGridView1.CurrentRow.Cells[1].Value?.ToString();

            if (string.IsNullOrEmpty(recordId))
            {
                MessageBox.Show("Не удалось определить ID выбранной записи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Текущая дата в правильном формате SQLite
            string todayDate = DateTime.Now.ToString("yyyy-MM-dd");

            try
            {
                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();

                    
                    string updateQuery = "UPDATE Issuance SET Status = 'Возвращено', ActualReturnDate = @ActualReturnDate WHERE Id = @Id;";

                    using (var cmd = new SqliteCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", recordId);
                        cmd.Parameters.AddWithValue("@ActualReturnDate", todayDate);
                        cmd.ExecuteNonQuery();
                    }

                    // Возвращаем книгу в инвентарь (увеличиваем доступное количество на 1)
                    if (!string.IsNullOrEmpty(invNumber))
                    {
                        string updateBooksQuery = "UPDATE Books SET Available = Available + 1 WHERE InvNumber = @InvNum;";
                        using (var cmdBooks = new SqliteCommand(updateBooksQuery, conn))
                        {
                            cmdBooks.Parameters.AddWithValue("@InvNum", invNumber);
                            cmdBooks.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Книга успешно возвращена в библиотеку!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadIssuanceData(); // Обновляем основную таблицу
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при оформлении возврата: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {
                MessageBox.Show("Выберите запись для удаления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string recordId = dataGridView1.CurrentRow.Cells["Id"].Value?.ToString();
            string invNumber = dataGridView1.CurrentRow.Cells["InvNumber"].Value?.ToString();

            if (string.IsNullOrEmpty(recordId))
            {
                MessageBox.Show("Не удалось получить ID записи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dialog = MessageBox.Show("Вы уверены, что хотите **удалить** эту запись без сохранения в историю?\n\n" +
                                         "Используйте только для исправления ошибок ввода.",
                                         "Подтверждение удаления",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.No) return;

            try
            {
                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Возвращаем книгу в фонд (+1)
                            if (!string.IsNullOrEmpty(invNumber))
                            {
                                string updateBookQuery = "UPDATE Books SET Available = Available + 1 WHERE InvNumber = @InvNumber";
                                using (var cmd = new SqliteCommand(updateBookQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@InvNumber", invNumber);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // 2. Удаляем **только одну** запись по ID
                            string deleteQuery = "DELETE FROM Issuance WHERE Id = @Id";
                            using (var cmd = new SqliteCommand(deleteQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Id", recordId);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();

                            MessageBox.Show("Запись успешно удалена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadIssuanceData(); // Обновляем таблицу
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Критическая ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Пожалуйста, выберите ячейку с номером билета или инвентарным номером книги в таблице!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем значение из выбранной ячейки и индекс её колонки
            string selectedValue = dataGridView1.CurrentCell.Value?.ToString() ?? "";
            int columnIndex = dataGridView1.CurrentCell.ColumnIndex;

            if (string.IsNullOrEmpty(selectedValue)) return;

            // Сохраняем значение в глобальный фильтр
            DatabaseHelper.SearchFilter = selectedValue;

            if (columnIndex == 0) // Выделена колонка " № Билета"
            {
                FormBDchitat readersForm = new FormBDchitat();
                readersForm.ShowDialog();
            }
            else if (columnIndex == 1) // Выделена колонка "Инв. Номер книги"
            {
                Form1 booksForm = new Form1(); // Если переименовал форму книг, укажи её имя класса
                booksForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выделите именно ячейку '№ Билета' или 'Инв. Номер книги' для поиска в базах.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Сбрасываем фильтр после закрытия формы
            DatabaseHelper.SearchFilter = "";
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void бДКнигToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 kn = new Form1();
            kn.Show();
        }

        private void генераторОтчётовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGenerOtch f2 = new FormGenerOtch();
            f2.Show();
        }

        private void бДЧитателейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBDchitat ch = new FormBDchitat();
            ch.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "База данных книг в библиотеке v1.0\n\n" +
                    "Разработано для хранения информации о книгах и читателях и проведения операций выдачи/возврата книг\n" +
                    "Функции:\n" +
                    "- Хранение данных о книгах\n" +
                    "- Хранение данных о читателях\n" +
                    "- Хранение данных о выдачах и возвратах книг\n" +
                    "- Генерация отчётов\n\n" +
                    "2026 год";
            MessageBox.Show(message, "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void SetupToolTips()
        {
            var tips = new Dictionary<Control, string> {
                // {label19, "" }, - макет

                {buttonFind, "Найти данные по выбранной ячейке\nВыберите номер билета или книги в таблице и нажмите на эту кнопку"},
                {buttonClear, "Удалить запись из таблицы\nВнимание - не считается за оформление возврата,\nиспользуйте в случае ошибки при заполнении"},
                {textBox1, "Введите инвентарный номер книги"},
                {textBox2, "Введите номер читательского билета"},
                {dateTimePicker1, "Введите предполагаемую дату для возврата книги"},
                {buttonGiveBook, "Выдать книгу читателю и занести данные о выдаче в таблицу" },
                {buttonStory, "Открыть историю возвращённых книг" },
                {buttonTakeBack, "Нажать в случае когда читатель вернул книгу\nУдалит запись о выдаче из таблицы\nСохранит данные о возврате в историю возвратов" }
            };

            foreach (var tip in tips)
            {
                toolTip1.SetToolTip(tip.Key, tip.Value);
            }
        }

        // История возвратов
        private void buttonStory_Click(object sender, EventArgs e)
        {
            Form2 historyForm = new Form2();
            historyForm.ShowDialog();
        }

        private void открытьZnaniumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://znanium.ru/",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось открыть сайт:\n{ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Игнорируем заголовок таблицы и проверку во время первичной загрузки данных
            if (e.RowIndex < 0 || dataGridView1.Rows[e.RowIndex].Cells["Id"].Value == null)
                return;

            var row = dataGridView1.Rows[e.RowIndex];
            string recordId = row.Cells["Id"].Value.ToString();

            // Берем измененные значения из ячеек таблицы
            string bilet = row.Cells["InvChitBilet"].Value?.ToString() ?? "";
            string invNum = row.Cells["InvNumber"].Value?.ToString() ?? "";
            string issueDate = row.Cells["IssueDate"].Value?.ToString() ?? "";
            string returnDate = row.Cells["ReturnDate"].Value?.ToString() ?? "";
            string status = row.Cells["Status"].Value?.ToString() ?? "";

            try
            {
                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();
                    // Запрос на обновление записи по её уникальному ID
                    string updateQuery = @"
                UPDATE Issuance 
                SET InvChitBilet = @Bilet, 
                    InvNumber = @Inv, 
                    IssueDate = @IDate, 
                    ReturnDate = @RDate, 
                    Status = @Status 
                WHERE Id = @Id;";

                    using (var cmd = new SqliteCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", recordId);
                        cmd.Parameters.AddWithValue("@Bilet", bilet);
                        cmd.Parameters.AddWithValue("@Inv", invNum);
                        cmd.Parameters.AddWithValue("@IDate", issueDate);
                        cmd.Parameters.AddWithValue("@RDate", returnDate);
                        cmd.Parameters.AddWithValue("@Status", status);

                        cmd.ExecuteNonQuery(); // Сохраняем изменения в SQLite
                    }
                }
                LoadIssuanceData();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка автосохранения изменений выдачи: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

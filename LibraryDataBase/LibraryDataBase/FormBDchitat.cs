using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace LibraryDataBase
{
    public partial class FormBDchitat : Form
    {

        private string readersFile = "readers.txt";  // файл для хранения читателей

        public FormBDchitat()
        {
            InitializeComponent();
            initializeDB();
            LoadReadersData();
            SetupToolTips();
        }

        // Настройка колонок таблицы
        private void initializeDB()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("InvChitBilet", "Номер читательского билета");
            dataGridView1.Columns.Add("FullName", "ФИО читателя");
            dataGridView1.Columns.Add("Class", "Класс");
            dataGridView1.Columns.Add("ClassTeacher", "Классный руководитель");
            dataGridView1.Columns.Add("Phone", "Телефон");
            dataGridView1.Columns.Add("ParentName", "ФИО родителя");
            dataGridView1.Columns.Add("ParentPhone", "Телефон родителя");
            dataGridView1.Columns.Add("RegDate", "Дата регистрации");

            dataGridView1.Columns["InvChitBilet"].Width = 200;
            dataGridView1.Columns["FullName"].Width = 180;
            dataGridView1.Columns["Class"].Width = 60;
            dataGridView1.Columns["ClassTeacher"].Width = 180;
            dataGridView1.Columns["Phone"].Width = 100;
            dataGridView1.Columns["ParentName"].Width = 180;
            dataGridView1.Columns["ParentPhone"].Width = 100;
            dataGridView1.Columns["RegDate"].Width = 120;

            dataGridView1.Columns["InvChitBilet"].ReadOnly = true;
        }

        private void LoadReadersData()
        {
            dataGridView1.Rows.Clear();

            using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();

                // Если фильтр есть - ищем по номеру билета
                string query = "SELECT * FROM Readers";
                if (!string.IsNullOrEmpty(DatabaseHelper.SearchFilter))
                {
                    query += " WHERE InvChitBilet = @filter";
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
                                reader["InvChitBilet"].ToString(),
                                reader["FullName"].ToString(),
                                reader["Class"].ToString(),
                                reader["ClassTeacher"].ToString(),
                                reader["Phone"].ToString(),
                                reader["ParentName"].ToString(),
                                reader["ParentPhone"].ToString(),
                                reader["RegDate"].ToString()
                            );
                        }
                    }
                }
            }
        }

        private void buttonAddbook_Click(object sender, EventArgs e)
        {
            // Проверка обязательных полей
            if (string.IsNullOrWhiteSpace(textBoxInvChit.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Заполните Номер билета и ФИО читателя!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();
                    string insertQuery = @"
                        INSERT INTO Readers (InvChitBilet, FullName, Class, ClassTeacher, Phone, ParentName, ParentPhone, RegDate)
                        VALUES (@Inv, @Name, @Class, @Teacher, @Phone, @PName, @PPhone, @RegDate);";

                    using (var cmd = new SqliteCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Inv", textBoxInvChit.Text.Trim());
                        cmd.Parameters.AddWithValue("@Name", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Class", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@Teacher", textBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone", textBox4.Text.Trim());
                        cmd.Parameters.AddWithValue("@PName", textBox5.Text.Trim());
                        cmd.Parameters.AddWithValue("@PPhone", textBox6.Text.Trim());
                        cmd.Parameters.AddWithValue("@RegDate", dateTimePicker1.Value.ToString("yyyy-MM-dd"));

                        cmd.ExecuteNonQuery();
                    }
                }

                LoadReadersData(); // Обновляем список на экране
                buttonChist_Click(null, null); // Очищаем текстовые поля
            }
            catch (SqliteException ex) when (ex.SqliteErrorCode == 19) // Нарушение UNIQUE / PRIMARY KEY
            {
                MessageBox.Show("Читатель с таким номером билета уже зарегистрирован!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения читателя в БД: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonChist_Click(object sender, EventArgs e)
        {
            textBoxInvChit.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void buttonDeleteOne_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string invNum = dataGridView1.SelectedRows[0].Cells["InvChitBilet"].Value.ToString();
                string name = dataGridView1.SelectedRows[0].Cells["FullName"].Value.ToString();

                var confirmResult = MessageBox.Show($"Вы уверены, что хотите удалить читателя {name} (Билет: {invNum})?",
                                                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                        {
                            conn.Open();
                            string deleteQuery = "DELETE FROM Readers WHERE InvChitBilet = @Inv";

                            using (var cmd = new SqliteCommand(deleteQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@Inv", invNum);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        LoadReadersData(); // Обновляем экран
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите строку в таблице целиком, кликнув слева от нее!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonDelAll_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("ВНИМАНИЕ! Вы уверены, что хотите ПОЛНОСТЬЮ очистить базу данных читателей?",
                                                "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                    {
                        conn.Open();
                        string truncateQuery = "DELETE FROM Readers";

                        using (var cmd = new SqliteCommand(truncateQuery, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadReadersData();
                    MessageBox.Show("База данных читателей успешно очищена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при очистке: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            string searchTxt = textBoxFind.Text.Trim();

            if (string.IsNullOrEmpty(searchTxt))
            {
                LoadReadersData();
                return;
            }

            dataGridView1.CellValueChanged -= dataGridView1_CellValueChanged;
            dataGridView1.Rows.Clear();

            try
            {
                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();
                    // Ищем совпадения по ФИО или по Классу
                    string searchQuery = "SELECT * FROM Readers WHERE FullName LIKE @Search OR Class LIKE @Search";

                    using (var cmd = new SqliteCommand(searchQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Search", "%" + searchTxt + "%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataGridView1.Rows.Add(
                                    reader["InvChitBilet"].ToString(),
                                    reader["FullName"].ToString(),
                                    reader["Class"].ToString(),
                                    reader["ClassTeacher"].ToString(),
                                    reader["Phone"].ToString(),
                                    reader["ParentName"].ToString(),
                                    reader["ParentPhone"].ToString(),
                                    reader["RegDate"].ToString()
                                );
                            }
                        }
                    }
                }

                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Ничего не найдено!", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            }
        }

        private void SetupToolTips()
        {
            var tips = new Dictionary<Control, string>
            {
                // {label19, "" }, - макет

                {textBoxInvChit, "Введите номер читательского билета" },
                {buttonFind, "Найти данные по заданному в поле поиска названию\nВнимание - сохраните БД перед сбросом поиска"},
                {buttonDeleteOne, "Удалить одну строку данных из БД\nПеред этим выберите полную строку в таблице"},
                {buttonAddbook, "Добавить читателя в БД"},
                {buttonChist, "Очистить все поля для ввода данных в БД"},
                {buttonDelAll, "Удалить все строки в БД"},
                {textBox1, "Введите ФИО читателя"},
                {textBox2, "Введите класс читателя"},
                {textBox3, "Введите ФИО классного руководителя класса читателя"},
                {textBox4, "Введите номер телефона читателя"},
                {textBox5, "Введите ФИО родителя читателя"},
                {textBox6, "Введите номер телефона родителя читателя"},
                {textBoxFind, "Введите ФИО или класс читателя"},
                {dateTimePicker1, "Введите дату регистрации читателя в библиотеке"},
            };

            foreach (var tip in tips)
            {
                toolTip1.SetToolTip(tip.Key, tip.Value);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                string invChitBilet = row.Cells["InvChitBilet"].Value?.ToString();

                if (string.IsNullOrEmpty(invChitBilet)) return;

                try
                {
                    using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                    {
                        conn.Open();
                        string updateQuery = @"
                            UPDATE Readers 
                            SET FullName = @Name, 
                                Class = @Class, 
                                ClassTeacher = @Teacher, 
                                Phone = @Phone, 
                                ParentName = @PName, 
                                ParentPhone = @PPhone, 
                                RegDate = @RegDate
                            WHERE InvChitBilet = @Inv;";

                        using (var cmd = new SqliteCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Inv", invChitBilet);
                            cmd.Parameters.AddWithValue("@Name", row.Cells["FullName"].Value?.ToString() ?? "");
                            cmd.Parameters.AddWithValue("@Class", row.Cells["Class"].Value?.ToString() ?? "");
                            cmd.Parameters.AddWithValue("@Teacher", row.Cells["ClassTeacher"].Value?.ToString() ?? "");
                            cmd.Parameters.AddWithValue("@Phone", row.Cells["Phone"].Value?.ToString() ?? "");
                            cmd.Parameters.AddWithValue("@PName", row.Cells["ParentName"].Value?.ToString() ?? "");
                            cmd.Parameters.AddWithValue("@PPhone", row.Cells["ParentPhone"].Value?.ToString() ?? "");
                            cmd.Parameters.AddWithValue("@RegDate", row.Cells["RegDate"].Value?.ToString() ?? "");

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка автосохранения читателя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

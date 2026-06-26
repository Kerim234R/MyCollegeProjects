using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Data.Sqlite;
using System.IO;

namespace LibraryDataBase
{
    public partial class FormGenerOtch : Form
    {
        public FormGenerOtch()
        {
            InitializeComponent();
            SetupDefaultStatuses();
            SetupToolTips();
        }

        private void SetupDefaultStatuses()
        {
            if (comboBox1 != null)
            {
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(new string[] { "Выдано", "Задерживается", "Возвращено" });
                if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int reportCount = 0;
            string date = DateTime.Now.ToString("yyyy-MM-dd_HH-mm");
            bool hasErrors = false;

            try
            {
                // ========== ОТЧЁТЫ ПО КНИГАМ ==========
                // 1. Все книги
                if (checkBox1.Checked)
                {
                    SaveReport($"Отчёт_Все_книги_{date}.txt", GetBooksReportContent("SELECT * FROM Books", null));
                    reportCount++;
                }

                // 2. По автору (checkBox3 -> textBox1)
                if (checkBox3.Checked)
                {
                    string author = textBox1.Text.Trim();
                    if (string.IsNullOrEmpty(author))
                    {
                        MessageBox.Show("Введите автора для отчёта!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hasErrors = true;
                    }
                    else
                    {
                        SaveReport($"Отчёт_Книги_по_автору_{date}.txt", GetBooksReportContent("SELECT * FROM Books WHERE Author LIKE @Param", "%" + author + "%"));
                        reportCount++;
                    }
                }

                // 3. По жанру (checkBox2 -> textBox2)
                if (checkBox4.Checked)
                {
                    string genre = textBox2.Text.Trim();
                    if (string.IsNullOrEmpty(genre))
                    {
                        MessageBox.Show("Введите жанр для отчёта!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hasErrors = true;
                    }
                    else
                    {
                        SaveReport($"Отчёт_Книги_по_жанру_{date}.txt", GetBooksReportContent("SELECT * FROM Books WHERE Genre LIKE @Param", "%" + genre + "%"));
                        reportCount++;
                    }
                }

                // 4. По году издания (checkBox4 -> textBox3)
                if (checkBox5.Checked)
                {
                    string year = textBox3.Text.Trim();
                    if (string.IsNullOrEmpty(year))
                    {
                        MessageBox.Show("Введите год издания для отчёта!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hasErrors = true;
                    }
                    else
                    {
                        SaveReport($"Отчёт_Книги_по_году_{date}.txt", GetBooksReportContent("SELECT * FROM Books WHERE Year = @Param", year));
                        reportCount++;
                    }
                }

                // 5. По месту хранения (checkBox5 -> textBox4)
                if (checkBox6.Checked)
                {
                    string loc = textBox4.Text.Trim();
                    if (string.IsNullOrEmpty(loc))
                    {
                        MessageBox.Show("Введите место хранения для отчёта!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hasErrors = true;
                    }
                    else
                    {
                        SaveReport($"Отчёт_Книги_по_месту_{date}.txt", GetBooksReportContent("SELECT * FROM Books WHERE Location LIKE @Param", "%" + loc + "%"));
                        reportCount++;
                    }
                }

                // ========== ОТЧЁТЫ ПО ЧИТАТЕЛЯМ ==========
                // 1. Все читатели
                if (checkBox2.Checked)
                {
                    SaveReport($"Отчёт_Все_читатели_{date}.txt", GetReadersReportContent("SELECT * FROM Readers", null));
                    reportCount++;
                }

                // 2. Читатели определенного класса (checkBox7 -> textBox5)
                if (checkBox7.Checked)
                {
                    string className = textBox5.Text.Trim();
                    if (string.IsNullOrEmpty(className))
                    {
                        MessageBox.Show("Введите класс для отчёта!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hasErrors = true;
                    }
                    else
                    {
                        SaveReport($"Отчёт_Читатели_класса_{className}_{date}.txt", GetReadersReportContent("SELECT * FROM Readers WHERE Class LIKE @Param", "%" + className + "%"));
                        reportCount++;
                    }
                }

                // ========== ОТЧЁТЫ ПО ВЫДАЧЕ КНИГ ==========
                // 1. Все операции выдачи (checkBox8)
                if (checkBox9.Checked)
                {
                    SaveReport($"Отчёт_Все_выдачи_{date}.txt", GetIssuanceReportContent("ALL", null));
                    reportCount++;
                }

                // 2. Отчёт по конкретному статусу (checkBox9 -> comboBox1)
                if (checkBox8.Checked)
                {
                    if (comboBox1.SelectedItem == null)
                    {
                        MessageBox.Show("Выберите статус для генерации отчёта!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hasErrors = true;
                    }
                    else
                    {
                        string selectedStatus = comboBox1.SelectedItem.ToString();
                        SaveReport($"Отчёт_Выдачи_со_статусом_{selectedStatus}_{date}.txt", GetIssuanceReportContent("STATUS", selectedStatus));
                        reportCount++;
                    }
                }

                // Финальный вывод результатов
                if (reportCount > 0)
                {
                    string finalMessage = $"Успешно сформировано отчётов: {reportCount}.\nФайлы сохранены в папку с программой.";
                    if (hasErrors)
                    {
                        finalMessage += "\n\nВнимание: Некоторые выбранные отчёты не были созданы из-за пустых полей ввода.";
                    }
                    MessageBox.Show(finalMessage, "Результат", MessageBoxButtons.OK, hasErrors ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
                }
                else if (!hasErrors)
                {
                    MessageBox.Show("Выберите хотя бы один пункт чек-бокса для создания отчёта!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Критическая ошибка при генерации отчётов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<string> GetIssuanceReportContent(string type, string statusFilter)
        {
            var result = new List<string>();
            result.Add("==================================================");
            if (type == "ALL")
                result.Add("       ОТЧЁТ: ВСЕ ОПЕРАЦИИ ВЫДАЧИ КНИГ");
            else
                result.Add($"       ОТЧЁТ: ВЫДАЧА КНИГ СО СТАТУСОМ \"{statusFilter.ToUpper()}\"");
            result.Add($"Дата создания: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
            result.Add("==================================================");
            result.Add("");

            int count = 0;
            string todayStr = DateTime.Now.ToString("yyyy-MM-dd");

            using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        I.Id, I.InvChitBilet, R.FullName AS ReaderName, 
                        I.InvNumber, B.Title AS BookTitle, 
                        I.IssueDate, I.ReturnDate, I.ActualReturnDate, I.Status 
                    FROM Issuance I
                    LEFT JOIN Readers R ON I.InvChitBilet = R.InvChitBilet
                    LEFT JOIN Books B ON I.InvNumber = B.InvNumber
                    ORDER BY I.Id DESC;";

                using (var cmd = new SqliteCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string currentStatus = reader["Status"].ToString();
                            string returnDate = reader["ReturnDate"].ToString();

                            if (currentStatus == "Выдано" && !string.IsNullOrEmpty(returnDate))
                            {
                                if (string.Compare(returnDate, todayStr) < 0)
                                    currentStatus = "Задерживается";
                            }

                            if (type == "STATUS" && currentStatus != statusFilter)
                                continue;

                            count++;
                            result.Add($"Запись ID: {reader["Id"]}");
                            result.Add($"   Читательский билет: {reader["InvChitBilet"]} ({reader["ReaderName"] ?? "Не найден в БД"})");
                            result.Add($"   Инв. Номер книги:   {reader["InvNumber"]} (\"{reader["BookTitle"] ?? "Не найдена в БД"}\")");
                            result.Add($"   Дата выдачи:        {reader["IssueDate"]}");
                            result.Add($"   Срок возврата:     {reader["ReturnDate"]} (План)");

                            if (currentStatus == "Возвращено")
                                result.Add($"   Фактически вернули: {reader["ActualReturnDate"]}");

                            result.Add($"   Текущий статус:     {currentStatus}");
                            result.Add("--------------------------------------------------");
                        }
                    }
                }
            }
            result.Add("");
            result.Add($"Всего найдено записей: {count}");
            return result;
        }

        private List<string> GetBooksReportContent(string query, string paramValue)
        {
            var result = new List<string>();
            result.Add("==================================================");
            result.Add("               ОТЧЁТ ПО КНИЖНОМУ ФОНДУ");
            result.Add($"Дата создания: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
            result.Add("==================================================");
            result.Add("");

            int count = 0;

            using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqliteCommand(query, conn))
                {
                    if (paramValue != null)
                        cmd.Parameters.AddWithValue("@Param", paramValue);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count++;
                            result.Add($"Инв. номер: {reader["InvNumber"]}");
                            result.Add($"   Название: {reader["Title"]}");
                            result.Add($"   Автор: {reader["Author"]}");
                            result.Add($"   Жанр: {reader["Genre"]}");
                            result.Add($"   Год издания: {reader["Year"]}");
                            result.Add($"   Издательство: {reader["Publisher"]}");
                            result.Add($"   Место хранения: {reader["Location"]}");
                            result.Add($"   Доступно/Всего: {reader["Available"]} из {reader["Quantity"]}");
                            result.Add("--------------------------------------------------");
                        }
                    }
                }
            }
            result.Add("");
            result.Add($"Всего найдено книг: {count}");
            return result;
        }

        private List<string> GetReadersReportContent(string query, string paramValue)
        {
            var result = new List<string>();
            result.Add("==================================================");
            result.Add("               ОТЧЁТ ПО ЧИТАТЕЛЯМ");
            result.Add($"Дата создания: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
            result.Add("==================================================");
            result.Add("");

            int count = 0;

            using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqliteCommand(query, conn))
                {
                    if (paramValue != null)
                        cmd.Parameters.AddWithValue("@Param", paramValue);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count++;
                            result.Add($"Билет: {reader["InvChitBilet"]}");
                            result.Add($"   ФИО: {reader["FullName"]}");
                            result.Add($"   Класс: {reader["Class"]} (Руководитель: {reader["ClassTeacher"]})");
                            result.Add($"   Телефон: {reader["Phone"]}");
                            result.Add($"   Родитель: {reader["ParentName"]} ({reader["ParentPhone"]})");
                            result.Add($"   Дата регистрации: {reader["RegDate"]}");
                            result.Add("--------------------------------------------------");
                        }
                    }
                }
            }
            result.Add("");
            result.Add($"Всего найдено читателей: {count}");
            return result;
        }

        private void SaveReport(string filename, List<string> content)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
            File.WriteAllLines(path, content, Encoding.UTF8);
        }

        private void SetupToolTips()
        {
            var tips = new Dictionary<Control, string>
            {
                { button1, "Сгенерировать отчёт/отчёты на основе выбранных вариантов" },
                { textBox1, "Введите ФИО автора книги" },
                { textBox2, "Введите жанр книги" },
                { textBox3, "Введите год издания книги" },
                { textBox4, "Введите место хранения книги" },
                { textBox5, "Введите класс читателя" },
            };

            foreach (var tip in tips)
            {
                if (tip.Key != null)
                {
                    toolTip1.SetToolTip(tip.Key, tip.Value);
                }
            }
        }
    }
}
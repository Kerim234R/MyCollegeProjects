using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace LibraryDataBase
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            InitializeGrid();
            LoadReturnHistory();
        }

        // Настройка колонок для dataGridView1
        private void InitializeGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Id", "ID операции");
            dataGridView1.Columns.Add("InvChitBilet", "№ Читательского билета");
            dataGridView1.Columns.Add("InvNumber", "Инв. номер книги");
            dataGridView1.Columns.Add("IssueDate", "Дата выдачи");
            dataGridView1.Columns.Add("ReturnDate", "Дата возврата (план)");
            dataGridView1.Columns.Add("ActualReturnDate", "Дата возврата (факт.)");
            dataGridView1.Columns.Add("Status", "Статус");

            // Автоматическое распределение ширины
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
        }

        // Загрузка историй возвратов из БД
        private void LoadReturnHistory()
        {
            dataGridView1.Rows.Clear();

            try
            {
                using (var conn = new SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();

                    string query = "SELECT Id, InvChitBilet, InvNumber, IssueDate, ReturnDate, ActualReturnDate, Status FROM Issuance WHERE Status = 'Возвращено' ORDER BY Id DESC;";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataGridView1.Rows.Add(
                                    reader["Id"].ToString(),
                                    reader["InvChitBilet"].ToString(),
                                    reader["InvNumber"].ToString(),
                                    reader["IssueDate"].ToString(),
                                    reader["ReturnDate"].ToString(),
                                    reader["ActualReturnDate"].ToString(),
                                    reader["Status"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке истории возвратов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
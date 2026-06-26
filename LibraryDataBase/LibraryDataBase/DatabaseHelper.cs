using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace LibraryDataBase
{
    public static class DatabaseHelper
    {
        private static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "library.db");
        public static string ConnectionString = $"Data Source={dbPath};";
        public static string SearchFilter = "";

        public static void InitializeDatabase()
        {

            // Таблица книг
            using (var conn = new SqliteConnection(ConnectionString))
            {
                conn.Open();

                string createBooksTable = @"
                    CREATE TABLE IF NOT EXISTS Books (
                        InvNumber TEXT PRIMARY KEY,
                        Title TEXT NOT NULL,
                        Author TEXT,
                        Year TEXT,
                        Publisher TEXT,
                        Genre TEXT,
                        Location TEXT,
                        Quantity INTEGER DEFAULT 1,
                        Available INTEGER DEFAULT 1
                    );";

                using (var cmd = new SqliteCommand(createBooksTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Таблица читателей
                string createReadersTable = @"
                    CREATE TABLE IF NOT EXISTS Readers (
                        InvChitBilet TEXT PRIMARY KEY,
                        FullName TEXT NOT NULL,
                        Class TEXT,
                        ClassTeacher TEXT,
                        Phone TEXT,
                        ParentName TEXT,
                        ParentPhone TEXT,
                        RegDate TEXT
                    );";

                using (var cmd = new SqliteCommand(createReadersTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Таблица выдачи/возврата книг
                string createIssuanceTable = @"
                    CREATE TABLE IF NOT EXISTS Issuance (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        InvChitBilet TEXT,
                        InvNumber TEXT,
                        IssueDate TEXT,
                        ReturnDate TEXT,
                        ActualReturnDate TEXT,
                        Status TEXT
                    );";

                using (var cmd = new SqliteCommand(createIssuanceTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        

    }
}
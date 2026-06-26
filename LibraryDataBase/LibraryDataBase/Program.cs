namespace LibraryDataBase
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // Новая добавленнная строчка для связи с БД в SQLite
            DatabaseHelper.InitializeDatabase(); // <--- БД проверится/создастся перед запуском форм
            Application.Run(new FormUchetKnig());
        }
    }
}
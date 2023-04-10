namespace GKLab3
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

            View.MainForm mainForm = new View.MainForm();
            Presenter presenter = new Presenter(mainForm);
            Application.Run(mainForm);
        }
    }
}
using HotToursRegister.Forms;
using Services;
using Services.Contracts;

namespace HotToursRegister
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
            ITourStorage tourStorage = new InMemoryStorage();
            Application.Run(new MainForm(tourStorage));
        }
    }
}

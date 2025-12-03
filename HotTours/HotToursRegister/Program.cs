using HotToursRegister.Forms;
using Microsoft.Extensions.Logging;
using Repository;
using Repository.Contracts;
using Serilog;

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
            var loggerFactory = new LoggerFactory();
            Application.Run(new MainForm(tourStorage));
        }
    }
}

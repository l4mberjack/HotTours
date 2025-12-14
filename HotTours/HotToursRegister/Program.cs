using HotTourRegister.Context;
using HotToursRegister.Forms;
using Microsoft.Extensions.Logging;
using Repository;
using Serilog;
using Services;

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
            var loggerConf = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.File("logs/log-.txt",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.Seq("http://localhost:5341",
                    apiKey: "tgWN1CkKsmiF6PKQbcly")
                .CreateLogger();

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog(loggerConf);
            });
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(new TourManager(new TourRepository(new TourContext()), loggerFactory)));
        }
    }
}

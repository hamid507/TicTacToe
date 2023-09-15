using Microsoft.Extensions.Configuration;
using TicTacToeGame.Config;

namespace TicTacToeGame
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Build a config object, using env vars and JSON providers.
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            
            // Get values from the config given their key and their target type.
            Settings? settings = config.GetRequiredSection("Settings").Get<Settings>();

            if (settings == null)
            {
                MessageBox.Show("appsettings.config file is invalid. App can't start.");
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmMain(settings));
        }
    }
}
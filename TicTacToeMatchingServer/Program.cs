// Build a config object, using env vars and JSON providers.
using Microsoft.Extensions.Configuration;
using TicTacToeMatchingServer;
using TicTacToeMatchingServer.Config;

IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

// Get values from the config given their key and their target type.
Settings? settings = config.GetRequiredSection("Settings").Get<Settings>();
if (settings == null)
{
    Console.WriteLine("appsettings.config file is invalid. App can't start.");
    return;
}
Server.Start(settings!);
using TicTacToeMatchingServer.Config;
using WebSocketSharp.Server;

namespace TicTacToeMatchingServer
{
    internal static class Server
    {
        public static void Start(Settings settings)
        {
            InitializeServiceSettings(settings);

            string serverUrl = settings.Endpoints.MatchingServer;
            var wss = new WebSocketServer(serverUrl);
            wss.AddWebSocketService<Room>("/Room");
            wss.AddWebSocketService<Move>("/Move");
            wss.Start();

            foreach (var path in wss.WebSocketServices.Paths)
            {
                Console.WriteLine($"Server started at {serverUrl}{path}");
            }

            Console.Read();
            wss.Stop();
        }

        private static void InitializeServiceSettings(Settings settings)
        {
            RoomService.Init(settings);
            MoveService.Init(settings);
        }
    }
}

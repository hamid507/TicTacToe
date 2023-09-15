using TicTacToeGame.Config;
using WebSocketSharp;

namespace TicTacToeGame
{
    public class Client
    {
        private Settings _settings;
        private string _route;

        public readonly WebSocket WebSocket;

        public Client(Settings settings, string route)
        {
            _settings = settings;
            _route = route;
            var ws = new WebSocket($"{_settings.Endpoints.MatchingServer.TrimEnd('/')}/{_route.TrimStart('/')}");
            WebSocket = ws;

            _ = Refresh(out _);
        }

        private bool Refresh(out Exception? ex)
        {
            if (!WebSocket.IsAlive)
            {
                try
                {
                    WebSocket.Connect();
                }
                catch(Exception e)
                {
                    ex = e;
                    return false;
                }
            }

            ex = null;
            return true;
        }

        public bool Send(string data)
        {
            return TrySend(data, out _);
        }

        public bool TrySend(string data, out Exception? ex)
        {
            if (!Refresh(out ex))
            {
                return false;
            }

            try
            {
                WebSocket.Send(data);
            }
            catch (Exception e)
            {
                ex = e;
                return false;
            }

            return true;
        }
    }
}

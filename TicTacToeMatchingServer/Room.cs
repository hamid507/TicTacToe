using WebSocketSharp;
using WebSocketSharp.Server;

namespace TicTacToeMatchingServer
{
    internal class Room : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine($"Received a new room message from client:");
            Console.WriteLine(e.Data);

            var roomJson = RoomService.Match(e.Data);

            Console.WriteLine($"Returning room match result:");
            Console.WriteLine(roomJson);

            Sessions.Broadcast(roomJson);
        }

        protected override void OnOpen()
        {
        }

        protected override void OnError(WebSocketSharp.ErrorEventArgs e)
        {
        }
    }
}

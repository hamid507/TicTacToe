using TicTacToeSharedLib.Utility;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace TicTacToeMatchingServer
{
    internal class Move : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine($"Received a new move message from client:");
            Console.WriteLine(e.Data);

            /*if(e.Data  == Constants.PassRequest)
            {
                Console.WriteLine($"Returning move result:");
                Console.WriteLine(Constants.PassResponse);
                Sessions.Broadcast(Constants.PassResponse);
                return;
            }*/

            var moveJson = MoveService.MakeMove(e.Data);

            Console.WriteLine($"Returning move result:");
            Console.WriteLine(moveJson);

            Sessions.Broadcast(moveJson);
        }
    }
}

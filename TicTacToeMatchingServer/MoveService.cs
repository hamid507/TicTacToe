using StackExchange.Redis;
using System.Text.Json;
using TicTacToeMatchingServer.Config;
using TicTacToeSharedLib.Models.Dtos.Game;
using TicTacToeSharedLib.Models.Entities;
using TicTacToeSharedLib.Utility;
using static TicTacToeSharedLib.Utility.Constants;

namespace TicTacToeMatchingServer
{
    public static class MoveService
    {
        private static IDatabase? _db;
        private static Settings? _settings;

        public static void Init(Settings settings)
        {
            _settings = settings;
            TryRefreshDb();
        }

        private static bool TryRefreshDb()
        {
            if (_settings == null)
            {
                return false;
            }

            if (_db == null)
            {
                try
                {
                    _db = ConnectionMultiplexer.Connect(_settings.Endpoints.RedisDb).GetDatabase();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        public static string? MakeMove(string data)
        {
            var response = new MoveResponseDto
            {
            };

            if (!TryRefreshDb())
            {
                response.ErrorMessage = "Unable to connect to database.";
                return JsonSerializer.Serialize(response);
            }

            // move validation begin

            var dto = JsonSerializer.Deserialize<MoveRequestDto>(data);
            if (dto == null)
            {
                //serialize failed
                response.ErrorMessage = "Unable to parse move";
                return JsonSerializer.Serialize(response);
            }

            //Check if the room exists
            var room = _db!.HashGet(RdKeyRooms, dto.RoomId);

            if (!room.HasValue)
            {
                //no room found with the given room id
                response.ErrorMessage = "Invalid room id";
                response.IsAborted = true;
                return JsonSerializer.Serialize(response);
            }

            var roomEntity = JsonSerializer.Deserialize<GameRoomEntity>(room.ToString());
            if (roomEntity == null)
            {
                //correct move, but room has no data. game is over (aborted)
                _db.HashDelete(RdKeyRooms, dto.RoomId);
                response.ErrorMessage = "Unable to parse the room";
                response.IsAborted = true;
                return JsonSerializer.Serialize(response);
            }

            response.GameRoom = roomEntity;
            if (dto.Pass)
            {
                response.IsValidMove = true;
                return JsonSerializer.Serialize(response);
            }

            if (roomEntity.Moves.Where(m => m.GameButton.ButtonName == dto.GameButton.ButtonName).Any())
            {
                response.ErrorMessage = "Invalid move. Already occupied.";
                return JsonSerializer.Serialize(response);
            }

            //validation end, correct move
            response.IsValidMove = true;

            roomEntity.Moves.Add(dto);

            var winner = CheckWinner(roomEntity.Moves);
            if (winner != null)
            {
                //game over, we have a winner
                roomEntity.GameResult = new()
                {
                    Winner = winner,
                    GameResultType = GameResultType.Won
                };
            }
            else if (roomEntity.Moves.Count == 9)
            {
                //draw, game over
                roomEntity.GameResult = new()
                {
                    GameResultType = GameResultType.Draw
                };
            }

            //save new move and game result
            _db.HashSet(RdKeyRooms, dto.RoomId, JsonSerializer.Serialize(roomEntity));
            return JsonSerializer.Serialize(response);
        }

        private static Winner? CheckWinner(List<MoveRequestDto> moves)
        {
            var playerOneButtons = moves
                .Where(m => m.Player.PlayerPosition == PlayerPosition.PlayerOne)
                .Select(m => m.GameButton)
                .ToList();

            var playerTwoButtons = moves
                .Where(m => m.Player.PlayerPosition == PlayerPosition.PlayerTwo)
                .Select (m => m.GameButton)
                .ToList();

            if (playerOneButtons.Count < 3 && playerTwoButtons.Count < 3)
            {
                return null;
            }

            var playerOneWinLine = CheckWinLines(playerOneButtons);
            if (playerOneWinLine.HasValue)
            {
                return new Winner
                {
                    PlayerPosition = PlayerPosition.PlayerOne,
                    GameWinLine = playerOneWinLine.Value
                };
            }

            var playerTwoWinLine = CheckWinLines(playerTwoButtons);
            if (playerTwoWinLine.HasValue)
            {
                return new Winner
                {
                    PlayerPosition = PlayerPosition.PlayerTwo,
                    GameWinLine = playerTwoWinLine.Value
                };
            }

            return null;
        }

        private static GameWinLine? CheckWinLines(List<GameButton> playerButtons)
        {
            //check for horizontal win lines
            var top = playerButtons.Where(b => b.Top).ToList().Count == 3;
            if (top)
            {
                return GameWinLine.Top;
            }

            var horizontalMiddle = playerButtons.Where(b => b.VerticalMiddle).ToList().Count == 3;
            if (horizontalMiddle)
            {
                return GameWinLine.HorizontalMiddle;
            }

            var bottom = playerButtons.Where(b => b.Bottom).ToList().Count == 3;
            if (bottom)
            {
                return GameWinLine.Bottom;
            }


            //check for vertical win lines
            var left = playerButtons.Where(b => b.Left).ToList().Count == 3;
            if (left)
            {
                return GameWinLine.Left;
            }

            var verticalMiddle = playerButtons.Where(b => b.HorizontalMiddle).ToList().Count == 3;
            if (verticalMiddle)
            {
                return GameWinLine.VerticalMiddle;
            }

            var right = playerButtons.Where(b => b.Right).ToList().Count == 3;
            if (right)
            {
                return GameWinLine.Right;
            }

            //check for diagonals
            var middle = playerButtons.Any(b => b.HorizontalMiddle && b.VerticalMiddle);
            if (!middle)
            {
                return null;
            }

            var topLeft = playerButtons.Any(b => b.Top && b.Left);
            var topRight = playerButtons.Any(b => b.Top && b.Right);

            if (!topLeft && !topRight) return null;

            if (topLeft && playerButtons.Any(b => b.Bottom && b.Right))
            {
                return GameWinLine.TopLeftDiagonal;
            }

            if (topRight && playerButtons.Any(b => b.Bottom && b.Left))
            {
                return GameWinLine.TopRightDiagonal;
            }

            return null;
        }
    }
}

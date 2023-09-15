using StackExchange.Redis;
using System.Text.Json;
using TicTacToeMatchingServer.Config;
using TicTacToeSharedLib.Models.Dtos;
using TicTacToeSharedLib.Models.Entities;
using TicTacToeSharedLib.Utility;
using static TicTacToeSharedLib.Utility.Constants;

namespace TicTacToeMatchingServer
{
    public static class RoomService
    {
        private static IDatabase? _db;
        private static Settings? _settings;
        private static readonly object _matchLock = new (); // Lock to ensure atomic room matching operations

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

        public static string? Match(string data)
        {
            lock (_matchLock)
            {
                if (!TryRefreshDb())
                {
                    return null;
                }

                var dto = JsonSerializer.Deserialize<RoomRequestDto>(data);
                if (dto == null)
                {
                    return null;
                }

                //Check if a room with a player exists
                var openRoomId = _db!.StringGet(RdOpenRoomId);

                if (openRoomId.HasValue)
                {

                    // A room is already created previously,
                    // so math current user and close the room
                    var openRoom = _db.HashGet(RdKeyRooms, openRoomId);
                    var roomEntity = JsonSerializer.Deserialize<GameRoomEntity>(openRoom.ToString());
                    if (roomEntity == null)
                    {
                        // there is a room, but deserialize failed. So, delete it
                        _db.HashDelete(RdKeyRooms, openRoomId);
                    }
                    else
                    {
                        //Room is successfully deserialized to an object

                        if (dto.CancelRequest)
                        {
                            // remove open room and key
                            _db.HashDelete(RdKeyRooms, openRoomId);
                            _db.StringGetDelete(RdOpenRoomId);
                            return string.Empty;
                        }

                        if (roomEntity.Player1.PlayerSign == null)
                        {
                            // Room has incorrect data, so again, delete it
                            _db.HashDelete(RdKeyRooms, openRoomId);
                        }
                        else if (roomEntity.Player1.Email == dto.Email)
                        {
                            // Same user already waiting in the room
                            return string.Empty;
                        }
                        else
                        {
                            //All good, assign the second user and close the room
                            var oppsiteSign = roomEntity.Player1.PlayerSign == PlayerSign.X ? PlayerSign.O : PlayerSign.X;
                            roomEntity.Player2.PlayerSign = oppsiteSign;
                            roomEntity.Player2.NickName = dto.NickName;
                            roomEntity.Player2.Email = dto.Email;
                            var json = JsonSerializer.Serialize(roomEntity);
                            _db.HashSet(RdKeyRooms, openRoomId, json);
                            _db.StringGetDelete(RdOpenRoomId);

                            return json;
                        }
                    }
                }

                //check if user exists in an active room
                var allRooms = _db.HashGetAll(RdKeyRooms);
                foreach (var room in allRooms)
                {
                    if (room.Value == RedisValue.Null) continue;

                    var roomItem = JsonSerializer.Deserialize<GameRoomEntity>(room.Value!);
                    
                    //If game is active
                    if (roomItem?.GameResult != null) continue;

                    //check if my room
                    if (dto.Email == roomItem?.Player1.Email || dto.Email == roomItem?.Player2.Email)
                    {
                        var myRoomJson = JsonSerializer.Serialize(roomItem);
                        return myRoomJson;
                    }
                }

                // No room exists, create a new one
                string newRoomId = Helper.CreateRandomToken();
                _db.StringSet(RdOpenRoomId, newRoomId);

                var newRoomEntity = new GameRoomEntity
                {
                    Id = newRoomId
                };

                newRoomEntity.Player1.PlayerSign = Helper.GetRandomEnumValue<PlayerSign>();
                newRoomEntity.Player1.NickName = dto.NickName;
                newRoomEntity.Player1.Email = dto.Email;

                var newJson = JsonSerializer.Serialize(newRoomEntity);
                _db.HashSet(RdKeyRooms, newRoomId, newJson);

                return newJson;
            }
        }
    }
}

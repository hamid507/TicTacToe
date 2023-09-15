using System.Data;
using System.Text.Json;
using TicTacToeGame.Config;
using TicTacToeSharedLib.Interfaces;
using TicTacToeSharedLib.Models.Dtos.Game;
using TicTacToeSharedLib.Models.Entities;
using TicTacToeSharedLib.Utility;
using WebSocketSharp;
using static TicTacToeGame.FormUtil;

namespace TicTacToeGame
{
    public partial class FrmGame : Form
    {
        private readonly string[] verticalPositions = new[] { "top", "middle", "bottom" };
        private readonly string[] horizontalPositions = new[] { "left", "middle", "right" };

        private readonly Settings _settings;
        private readonly GameRoomEntity _gameRoom;
        private readonly bool _isPlayer1;

        private bool FirstToPlay, IsMyTurn;

        private readonly Client _moveClient;
        private bool _running;

        private System.Timers.Timer _timer;
        private TimeSpan _ts = ResetGameTime();

        public FrmGame(Settings settings, GameRoomEntity gameRoom)
        {
            InitializeComponent();
            _settings = settings;
            _gameRoom = gameRoom;
            _isPlayer1 = _gameRoom.Player1.Email == FrmLogin.LoggedUser?.Email;
            FirstToPlay = _gameRoom.Player1.PlayerSign == (_isPlayer1 ? PlayerSign.X : PlayerSign.O);
            IsMyTurn = _gameRoom.Moves.Count == 0 ? FirstToPlay : _gameRoom.Moves.Last().Player.Email != FrmLogin.LoggedUser?.Email;

            //Initialize client
            _moveClient = new Client(_settings, "/Move");
            _moveClient.WebSocket.OnMessage += MoveResponse;
            _moveClient.WebSocket.OnError += Ws_OnError;

            _timer = new System.Timers.Timer
            {
                Interval = 1000,
                AutoReset = true
            };
            _timer.Elapsed += _timer_Elapsed;
        }

        private void Ws_OnError(object? sender, WebSocketSharp.ErrorEventArgs e)
        {
            //For debug
            //MessageBox.Show(FrmLogin.LoggedUser!.Email + " MOVE CLIENT ERROR : " + e.Exception);
        }

        private static TimeSpan ResetGameTime()
        {
            return TimeSpan.FromSeconds(Constants.GameTimeSeconds);
        }

        private void _timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            if (!_running)
            {
                StopTimer();
                return;
            }

            if (_ts == TimeSpan.Zero)
            {
                if (IsMyTurn)
                {
                    PassTurn();
                }
                return;
            }

            if (_ts < TimeSpan.Zero)
            {
                if (IsMyTurn)
                {
                    ResetTimer();
                }
                return;
            }

            _ts = _ts.Add(-TimeSpan.FromMilliseconds(_timer.Interval));
            var labelTimeText = (_ts < TimeSpan.Zero ? "-" : "") + _ts.ToString(@"m\:ss");
            UpdateControl(lblTimer, labelTimeText, ControlUpdateType.Text);
        }

        public void PassTurn()
        {
            var request = new MoveRequestDto
            {
                Pass = true,
                Player = _isPlayer1 ? _gameRoom.Player1 : _gameRoom.Player2,
                RoomId = _gameRoom.Id
            };
            var message = JsonSerializer.Serialize(request);

            _moveClient.Send(message);
        }

        private void ResetTimer()
        {
            StopTimer();
            StartTimer();
        }

        private void StopTimer()
        {
            _timer.Stop();
            _ts = ResetGameTime();
            UpdateControl(lblTimer, _ts.ToString(@"m\:ss"), ControlUpdateType.Text);
        }

        private void StartTimer()
        {
            _timer.Start();
        }

        private void GameMoveButton_Click(object sender, EventArgs e)
        {
            if (sender is not Button button) return;

            var name = button.Name;
            var nameParts = ValidateButtonName(name);
            if (nameParts == null) return;

            var move = GenerateMove(name, nameParts);
            ClientNewMoveRequest(move);
        }

        private string[]? ValidateButtonName(string name)
        {
            var nameParts = name.Split('_');
            if (nameParts.Length != 3) return null;
            if (nameParts[0] != "btn") return null;
            if (!verticalPositions.Contains(nameParts[1])) return null;
            if (!horizontalPositions.Contains(nameParts[2])) return null;

            return nameParts;
        }

        private MoveRequestDto GenerateMove(string name, string[] nameParts)
        {
            var move = new MoveRequestDto();

            var gameButton = new GameButton
            {
                ButtonName = name,
                Top = nameParts[1] == "top",
                VerticalMiddle = nameParts[1] == "middle",
                Bottom = nameParts[1] == "bottom",
                Left = nameParts[2] == "left",
                HorizontalMiddle = nameParts[2] == "middle",
                Right = nameParts[2] == "right"
            };

            move.GameButton = gameButton;
            move.Player = _isPlayer1 ? _gameRoom.Player1 : _gameRoom.Player2;
            move.RoomId = _gameRoom.Id;
            move.MoveTime = DateTime.UtcNow;

            return move;
        }

        private void FrmGame_Shown(object sender, EventArgs e)
        {
            LoadRoom();
        }

        private void LoadRoom()
        {
            ControlBox = false;

            txtUserNickName.Text = FrmLogin.LoggedUser?.NickName;
            txtUserEmail.Text = FrmLogin.LoggedUser?.Email;
            txtUserPoints.Text = FrmLogin.LoggedUser?.BonusInfo?.TotalBonus.ToString();
            txtRoom.Text = $"{_gameRoom.Id.Substring(0, 7)}/{new string(_gameRoom.Id.TakeLast(3).ToArray())}";

            lblPlayer1Sign.Text = _gameRoom.Player1.PlayerSign.ToString();
            txtPlayer1.Text = _gameRoom.Player1.NickName;

            lblPlayer2Sign.Text = _gameRoom.Player2.PlayerSign.ToString();
            txtPlayer2.Text = _gameRoom.Player2.NickName;

            _running = _gameRoom.GameResult == null;

            var lastMove = _gameRoom.Moves.LastOrDefault();
            if (lastMove != null)
            {
                CheckGameResult(_gameRoom);
            }

            ApplyMovesToUI(_gameRoom.Moves);

            _ts = ResetGameTime() - (lastMove != null ? (DateTime.UtcNow - lastMove.MoveTime) : TimeSpan.Zero);
            ReDrawUI();
        }

        private void ReDrawUI()
        {
            ApplyPanelVisivility();
            ApplyTurnArrow();
            ApplyUserTurnMessage();
            ApplyTimer();
        }

        private void ApplyPanelVisivility()
        {
            UpdateControl(pnlGame, IsMyTurn && _running, ControlUpdateType.Enabled);
        }

        private void ApplyTurnArrow()
        {
            var player1Turn = _isPlayer1 == IsMyTurn;
            UpdateControl(lblArrow1, player1Turn && _running, ControlUpdateType.Visible);
            UpdateControl(lblArrow2, !player1Turn && _running, ControlUpdateType.Visible);
        }

        private void ApplyUserTurnMessage()
        {
            UpdateControl(lblUserTurn, _running ? IsMyTurn ? "!It is your turn" : "...Waiting for the opponent to make a move" : string.Empty, ControlUpdateType.Text);
        }

        private void ApplyTimer()
        {
            StopTimer();

            if (_running)
            {
                StartTimer();
            }
        }

        private void ClientNewMoveRequest(MoveRequestDto request)
        {
            //Generate request message
            var message = JsonSerializer.Serialize(request);

            if (!_moveClient.Send(message))
            {
                MessageBox.Show("Failed to connect to the matching server.");
            }
        }

        private void MoveResponse(object? sender, MessageEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Data)) return;

            var dto = JsonSerializer.Deserialize<MoveResponseDto>(e.Data);
            if (dto == null) return;

            if (!dto.IsValidMove)
            {
                if (IsMyTurn)
                {
                    MessageBox.Show(dto.ErrorMessage);
                }
                return;
            }

            if (dto?.GameRoom == null) return;

            if (dto.IsAborted)
            {
                EndGame("Game aborted.");
            }

            var moves = dto.GameRoom.Moves;
            if (moves == null) return;

            //valid move, process the move
            ApplyMovesToUI(moves);
            CheckGameResult(dto.GameRoom);

            IsMyTurn = !IsMyTurn;

            ReDrawUI();
        }

        private void CheckGameResult(GameRoomEntity room)
        {
            if (room.GameResult == null)
            {
                return;
            }
            bool draw = room.GameResult.GameResultType == GameResultType.Draw;
            if (draw)
            {
                EndGame("Draw.");
            }
            else
            {
                bool youWon = room.GameResult.Winner!.PlayerPosition == PlayerPosition.PlayerOne == _isPlayer1;
                EndGame($"You {(youWon ? "win" : "lose")}!");
            }
        }

        private void EndGame(string message)
        {
            _running = false;
            UpdateControl(lblInfo, message, ControlUpdateType.Text);
            UpdateControl(null, true, ControlUpdateType.ControlBox, this);
        }

        private void ApplyMovesToUI(List<MoveRequestDto> moves)
        {
            foreach (var move in moves)
            {
                var buttonToApply = pnlGame.Controls.OfType<Button>().Where(b => b.Name == move.GameButton.ButtonName).FirstOrDefault();
                UpdateControl(buttonToApply, move.Player.PlayerSign?.ToString() ?? string.Empty, ControlUpdateType.Text);
            }
        }

        private void FrmGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            (Application.OpenForms["FrmMain"] as FrmMain)?.GameFormClosed();
        }

        private void btnFakeClose_Click(object sender, EventArgs e)
        {
            Hide();
            (Application.OpenForms["FrmMain"] as FrmMain)?.GameFormHidden(this);
        }

        private void FrmGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            _moveClient.WebSocket.Close();
        }

        internal void MainFormClosing()
        {
            _moveClient.WebSocket.Close();
        }
    }
}

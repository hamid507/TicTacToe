namespace TicTacToeSharedLib.Utility
{
    public static class Constants
    {
        #region api

        public const int DefaultRetryAfterSeconds = 10;
        public const int ApiTimeoutSeconds = 1800;

        #endregion

        #region game

        public const int GameTimeSeconds = 30;

        #endregion

        #region redis keys

        public const string RdKeyUsers = "users";
        public const string RdKeyNicknames = "nicknames";
        public const string RdKeyUserId = "userId";
        public const string RdKeyRooms = "rooms";
        public const string RdOpenRoomId = "open-room-id";

        #endregion

        #region error messages

        public const string ErrMsgWrongEmailOrPass = "Wrong email or password.";
        public const string ErrMsgEmptyJson = "Database error: Empty json.";
        public const string ErrMsgJsonDeserializeFailed = "Database error. Deserialize failed.";
        public const string ErrMsgEmailTaken = "This email is already taken.";
        public const string ErrMsgNicknameTaken = "This nickname is already taken.";
        public const string ErrMsgUserNotVerified = "User not verified.";
        public const string ErrMsgInvalidToken = "Invalid token.";
        public const string ErrMsgEmailAlreadyVerified = "Email already verified.";
        public const string ErrMsgTokenExpired = "Token expired.";

        #endregion

        #region matching server

        //public const string PassRequest = "PASS";
        //public const string PassResponse = "PASSED";

        #endregion
    }
}
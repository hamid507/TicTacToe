namespace TicTacToeSharedLib.Utility
{
    public enum ToolExitCode
    {
        Success = 0,
        UndefinedFailure = 1,
        MissingInputFiles = 2,
        OutputFileAlreadyExists = 3,
        MissingJobType = 4,
        MissingUrl = 5,
        HealthCheckFailed = 6
    }

    public enum JobPriority
    {
        Low = 0,
        Default = 1,
        High = 2
    }

    public enum JobStatus
    {
        Undefined = -1,
        NotStarted = 0,
        Running = 1,
        Succeeded = 2,
        Failed = 3
    }

    [Flags]
    public enum LogLevel
    {
        OFF = 0,
        MINIMUM = 1,
        SERVER = 2,
        VERBOSE = 4,
        DEBUG = 8
    }

    public enum ProcessStatus
    {
        Undefined = -1,
        NotStarted = 0,
        Running = 1,
        Succeeded = 2,
        Failed = 3
    }

    public enum ApiMethod
    {
        LoginAsync = 1,
        RegisterAsync = 2,
        VerifyAsync = 3,
        NewGameAsync = 4
    }

    public enum BonusStreak
    {
        Day1 = 10,
        Day2 = 30,
        Day3 = 70,
        Day4 = 120,
        Day5 = 180,
        Day6 = 250,
        Day7 = 500
    }

    public enum UserActivity
    {
        Login = 1,
        Register = 2,
        Verify = 3
    }

    public enum RepoResponseType
    {
        Unknown,
        Ok,
        Created,
        InternalServerError,
        BadRequest,
        NotFound,
        NoContent
    }

    public enum PlayerPosition
    {
        PlayerOne,
        PlayerTwo
    }

    public enum PlayerSign
    {
        X,
        O
    }

    public enum GameWinLine
    {
        Top,
        HorizontalMiddle,
        Bottom,
        Left,
        VerticalMiddle,
        Right,
        TopLeftDiagonal,
        TopRightDiagonal
    }

    public enum GameResultType
    {
        Won,
        Draw,
        Abort
    }

    public enum ControlUpdateType
    {
        Text,
        Visible,
        Enabled,
        ControlBox
    }
}
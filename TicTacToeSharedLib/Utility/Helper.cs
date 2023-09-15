using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace TicTacToeSharedLib.Utility
{
    public static class Helper
    {
        public static LogLevel CurrentLogLevel { get; set; } = LogLevel.MINIMUM;

        public static IEnumerable<KeyValuePair<string, string>> ConvertToKvpEnumerable(IReadOnlyList<string>? headers,
            char separator = '=')
        {
            if (headers == null) yield break;

            foreach (var header in headers)
            {
                var headerKv = header.Split(separator);
                if (headerKv.Length != 2)
                {
                    continue;
                }

                var key = headerKv[0];
                var value = headerKv[1];

                if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value))
                {
                    continue;
                }

                var kv = new KeyValuePair<string, string>(key, value);
                yield return kv;
            }
        }

        public static void ConsoleWriteLine(string? s, bool error = false, LogLevel logLevel = LogLevel.MINIMUM | LogLevel.VERBOSE, bool amend = false)
        {
            if (CurrentLogLevel == LogLevel.OFF || !logLevel.HasFlag(CurrentLogLevel))
            {
                return;
            }

            if (amend)
            {
                // This ensures to amend the latest message instead of adding a new one
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }

            if (error)
            {
                Console.Error.WriteLine(FormatConsoleMessage(s));
            }
            else
            {
                Console.WriteLine(FormatConsoleMessage(s));
            }
        }

        public static bool TryGetDirectoryName(string path, out string? directoryName, out Exception? exception)
        {
            try
            {
                directoryName = Path.GetDirectoryName(path);
                exception = null;
                return true;
            }
            catch (Exception e)
            {
                directoryName = null;
                exception = e;
                return false;
            }
        }

        public static bool TryCreateDirectory(string path, out Exception? exception)
        {
            try
            {
                Directory.CreateDirectory(path);
                exception = null;
                return true;
            }
            catch (Exception e)
            {
                exception = e;
                return false;
            }
        }

        public static bool TryGetFileName(string? path, out string? fileName, out Exception? exception)
        {
            try
            {
                fileName = Path.GetFileName(path);
                exception = null;
                return true;
            }
            catch (Exception e)
            {
                fileName = null;
                exception = e;
                return false;
            }
        }

        public static bool TrySaveFile(string path, Stream readStream, out Exception? exception,
            bool disposeStream = true, int bufferSize = 4096)
        {
            try
            {
                if (readStream == null)
                {
                    throw new ArgumentNullException(nameof(readStream));
                }

                using Stream writeStream = File.OpenWrite(path);
                var buffer = new byte[bufferSize];
                int bytesRead;
                do
                {
                    bytesRead = readStream.Read(buffer, 0, buffer.Length);
                    writeStream.Write(buffer, 0, bytesRead);
                } while (bytesRead > 0);

                if (disposeStream)
                {
                    readStream.Dispose();
                }

                exception = null;
                return true;
            }
            catch (Exception e)
            {
                exception = e;
                return false;
            }
        }

        public static HttpStatusCode[] GetExpectedStatusCodes(ApiMethod apiMethod)
        {
            switch (apiMethod)
            {
                case ApiMethod.RegisterAsync: return new[] { HttpStatusCode.Created };
                default: return new[] { HttpStatusCode.OK };
            }
        }

        public static string FormatConsoleMessage(string? s)
        {
            return $"[{DateTime.UtcNow:yyyy/MMM/dd HH:mm:ss:fff}] {s}";
        }

        public static Guid ExtractGuidFromUrl(string url)
        {
            const string pattern = @"/(\w{8}-\w{4}-\w{4}-\w{4}-\w{12})";
            var regex = new Regex(pattern);
            var match = regex.Match(url);

            return match.Success ? Guid.Parse(match.Groups[1].Value) : Guid.Empty;
        }

        public static string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }

        public static T GetRandomEnumValue<T>() where T : struct, Enum
        {
            T[] values = Enum.GetValues<T>();
            return values[new Random().Next(values.Length)];
        }
    }
}
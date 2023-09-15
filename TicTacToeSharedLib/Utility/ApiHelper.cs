using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using TicTacToeSharedLib.Interfaces;
using TicTacToeSharedLib.Models.Api.Response;
using TicTacToeSharedLib.Models.Dtos;
using static TicTacToeSharedLib.Utility.Helper;

namespace TicTacToeSharedLib.Utility
{
    public static class ApiHelper
    {
        #region private methods

        private static string MergeBaseUrlAndPath(string baseUrl, string path)
        {
            return string.Concat(baseUrl.TrimEnd('/'), '/', path.TrimStart('/'));
        }

        private static async Task<TResp> SendAsync<TResp, TDto>(string baseUrl, string path, HttpMethod httpMethod,
            ApiMethod apiMethod, CancellationToken? cancellationToken = null, HttpContent? requestContent = null,
            int? clientTimeout = null, AuthenticationHeaderValue? authHeaderValue = null, Version? version = null,
            KeyValuePair<string, string>[]? headers = null, bool deserializeDto = true, bool writeToConsole = true,
            bool readContentString = false, bool readContentStream = false)
            where TDto : class, IDto, new()
            where TResp : ApiResponse<TDto>, new()
        {
            var result = new TResp
            {
                Success = false
            };

            var sourceMethodName = Enum.GetName(apiMethod);

            try
            {
                var uri = new Uri(MergeBaseUrlAndPath(baseUrl, path));

                using var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(clientTimeout ?? Constants.ApiTimeoutSeconds);

                using var request = new HttpRequestMessage(httpMethod, uri);
                request.Headers.ExpectContinue = true;

                var expectedStatusCodes = GetExpectedStatusCodes(apiMethod);
                cancellationToken ??= CancellationToken.None;

                if (authHeaderValue != null)
                {
                    request.Headers.Authorization = authHeaderValue;
                }

                if (requestContent != null)
                {
                    request.Content = requestContent;
                }

                if (version != null)
                {
                    request.Version = version;
                }

                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }

                if (writeToConsole)
                {
                    ConsoleWriteLine($"Request:{Environment.NewLine}{request}", false, LogLevel.VERBOSE);
                    ConsoleWriteLine($"Waiting for {sourceMethodName}...");
                }

                var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead,
                    cancellationToken.Value);
                if (writeToConsole)
                {
                    ConsoleWriteLine($"Response:{Environment.NewLine}{response}", false, LogLevel.VERBOSE);
                }

                result.RetryAfter = response.Headers.RetryAfter?.Delta;

                if (readContentStream)
                {
                    ConsoleWriteLine($"Waiting for response.Content.ReadAsByteArrayAsync...", false, LogLevel.VERBOSE);
                    var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken.Value);
                    result.FileStream = contentStream;
                }

                if (!expectedStatusCodes.Contains(response.StatusCode))
                {
                    var errorContent = readContentStream
                        ? await new StreamReader(result.FileStream).ReadToEndAsync()
                        : await response.Content.ReadAsStringAsync(cancellationToken.Value);

                    result.ErrorMessage =
                        $"{sourceMethodName} failed: Did not receive the expected '{string.Join('|', expectedStatusCodes)}' status code. Reason: '{response.ReasonPhrase}' {Environment.NewLine}Error content as text:{Environment.NewLine}{errorContent}";
                    result.ShortErrorMessage = response.ReasonPhrase;
                    result.ErrorContent = errorContent;
                    return result;
                }

                if (readContentString || deserializeDto)
                {
                    ConsoleWriteLine($"Waiting for response.Content.ReadAsStringAsync...", false, LogLevel.VERBOSE);
                    var content = await response.Content.ReadAsStringAsync(cancellationToken.Value);

                    if (writeToConsole)
                    {
                        ConsoleWriteLine("Response content as text:", false, LogLevel.VERBOSE);
                        ConsoleWriteLine($"{content}", false, LogLevel.VERBOSE | LogLevel.SERVER);
                    }

                    if (deserializeDto)
                    {
                        TDto? responseObj;
                        try
                        {
                            responseObj = JsonSerializer.Deserialize<TDto>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                        }
                        catch (Exception e)
                        {
                            result.ErrorMessage =
                                $"{sourceMethodName} failed: Deserialize exception. Message: '{e.Message}'";
                            result.ShortErrorMessage = "System error. Deserialize exception.";
                            return result;
                        }

                        if (responseObj == default)
                        {
                            result.ErrorMessage = $"{sourceMethodName} failed: Deserialize error. Object is null.";
                            result.ShortErrorMessage = "System error. Deserialize failed.";
                            return result;
                        }

                        result.Dto = responseObj;
                    }
                }

                result.Success = true;
                result.ErrorMessage = string.Empty;
                result.ShortErrorMessage = string.Empty;
                return result;
            }
            catch (Exception e)
            {
                result.ErrorMessage = $"{sourceMethodName} exception occurred. Message: '{e.Message}'";
                result.ShortErrorMessage = e.Message;
                ConsoleWriteLine($"e.ToString(){Environment.NewLine}{e}", true, LogLevel.VERBOSE);
                return result;
            }
        }

        #endregion

        public static async Task<UserLoginResponse> LoginAsync(string url, UserLoginRequestDto requestDto,
            CancellationToken cancellationToken, KeyValuePair<string, string>[]? headers)
        {
            var path = "/Users/Login";
            var method = HttpMethod.Post;

            var requestContent = JsonContent.Create(requestDto);

            const ApiMethod apiMethod = ApiMethod.LoginAsync;

            return await SendAsync<UserLoginResponse, UserLoginResponseDto>(url, path, method, apiMethod, cancellationToken,
                requestContent, headers: headers);
        }

        public static async Task<UserRegisterResponse> RegisterAsync(string url, UserRegisterRequestDto requestDto,
            CancellationToken cancellationToken, KeyValuePair<string, string>[]? headers)
        {
            var path = "/Users/Register";
            var method = HttpMethod.Post;

            var requestContent = JsonContent.Create(requestDto);

            const ApiMethod apiMethod = ApiMethod.RegisterAsync;

            return await SendAsync<UserRegisterResponse, UserRegisterResponseDto>(url, path, method, apiMethod, cancellationToken,
                requestContent, headers: headers);
        }

        public static async Task<UserVerifyResponse> VerifyAsync(string url, UserVerifyRequestDto requestDto,
            CancellationToken cancellationToken, KeyValuePair<string, string>[]? headers)
        {
            var path = "/Users/Verify";
            var method = HttpMethod.Post;

            var requestContent = JsonContent.Create(requestDto);

            const ApiMethod apiMethod = ApiMethod.VerifyAsync;

            return await SendAsync<UserVerifyResponse, UserVerifyResponseDto>(url, path, method, apiMethod, cancellationToken,
                requestContent, headers: headers);
        }
    }
}
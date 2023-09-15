using AutoMapper;
using StackExchange.Redis;
using System.Text.Json;
using TicTacToeApi.Data.Abstraction;
using TicTacToeApi.Validations;
using TicTacToeApi.Validations.Implementation;
using TicTacToeSharedLib.Models.Dtos;
using TicTacToeSharedLib.Models.Entities;
using TicTacToeSharedLib.Models.Repo.Response;
using TicTacToeSharedLib.Utility;
using static TicTacToeSharedLib.Utility.Constants;
using static TicTacToeSharedLib.Utility.Helper;

namespace TicTacToeApi.Data.Implementation
{
    public class UserRepo : IUserRepo
    {
        private readonly IDatabase _db;
        private readonly IMapper _mapper;

        public UserRepo(IConnectionMultiplexer connection, IMapper mapper)
        {
            _db = connection.GetDatabase();
            _mapper = mapper;
        }

        #region private methods

        private UserEntity? TryGetUser(string? email, out string errorMessage, out RepoResponseType responseType)
        {
            var user = _db.HashGet(RdKeyUsers, email);
            if (!user.HasValue)
            {
                errorMessage = ErrMsgWrongEmailOrPass;
                responseType = RepoResponseType.BadRequest;
                return null;
            }

            string? json = user;

            if (string.IsNullOrWhiteSpace(json))
            {
                errorMessage = ErrMsgEmptyJson;
                responseType = RepoResponseType.InternalServerError;
                return null;
            }

            var entity = JsonSerializer.Deserialize<UserEntity>(json);
            if (entity == null)
            {
                errorMessage = ErrMsgJsonDeserializeFailed;
                responseType = RepoResponseType.InternalServerError;
                return null;
            }

            errorMessage = string.Empty;
            responseType = RepoResponseType.Unknown;
            return entity;
        }

        private void CalculateBonus(UserEntity userEntity)
        {
            var today = DateTime.UtcNow;

            var bonusInfo = userEntity.BonusInfo;
            if (bonusInfo == null) bonusInfo = new();

            bool everLogged = bonusInfo.LastLoginDate.HasValue;
            bool isInStreak = everLogged && bonusInfo.LastLoginDate!.Value.Date == today.AddDays(-1).Date;
            var newStreak = isInStreak ? bonusInfo.LoginStreak % 7 + 1 : 1;
            var parsed = Enum.TryParse($"Day{newStreak}", false, out BonusStreak b);
            bool loggedToday = everLogged && bonusInfo.LastLoginDate!.Value.Date == today.Date;
            var calculatedBonus = parsed && isInStreak ? (int)b : loggedToday ?  0 : (int)BonusStreak.Day1;

            bonusInfo.LastLoginDate = today.Date;
            if (calculatedBonus != 0)
            {
                bonusInfo.LoginStreak = parsed ? newStreak : 1;
            }
            bonusInfo.CalculatedBonus = calculatedBonus;
            bonusInfo.TotalBonus += calculatedBonus;

            var newJson = JsonSerializer.Serialize(userEntity);
            _db.HashSet(RdKeyUsers, userEntity.Email, newJson);
        }

        #endregion

        public UserRegisterRepoResponse Register(UserRegisterRequestDto dto)
        {
            var response = new UserRegisterRepoResponse()
            {
                Success = false
            };

            bool valid = DtoValidator.TryValidate<UserRegisterRequestDto, UserRegisterValidator>(dto, out string? errors);
            if (!valid)
            {
                response.ErrorMessage = errors;
                response.RepoResponseType = RepoResponseType.BadRequest;
                return response;
            }

            var existingUserEntity = TryGetUser(dto.Email, out _, out _);

            if (existingUserEntity != null)
            {
                response.ErrorMessage = ErrMsgEmailTaken;
                response.RepoResponseType = RepoResponseType.BadRequest;
                return response;
            }

            //Check if any user in database already reserved this nickname
            /*
            var allUsers = db.HashGetAll(RdUsersKey);
            foreach(var hashEntry in allUsers)
            {
                string? itemJson = hashEntry.Value;
                if (itemJson == null) continue;

                var item = JsonSerializer.Deserialize<UserEntity>(itemJson);
                if (item == null) continue;

                if(item.NickName == dto.NickName)
                {
                    response.ErrorMessage = "This nickname is already taken.";
                    response.RepoResponseType = RepoResponseType.BadRequest;
                    return response;
                }
            }*/

            bool isNicknameTaken = _db.SetContains(RdKeyNicknames, dto.NickName);

            if (isNicknameTaken)
            {
                response.ErrorMessage = ErrMsgNicknameTaken;
                response.RepoResponseType = RepoResponseType.BadRequest;
                return response;
            }

            var userEntity = _mapper.Map<UserEntity>(dto);

            CryptoHelper.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] salt);
            userEntity.PasswordHash = passwordHash;
            userEntity.PasswordSalt = salt;

            //Generate and assign a new user id
            var userId = _db.StringIncrement(RdKeyUserId);
            userEntity.Id = userId;

            userEntity.VerificationToken = CreateRandomToken();

            var userJson = JsonSerializer.Serialize(userEntity);
            _db.HashSet(RdKeyUsers, dto.Email, userJson);
            _db.SetAdd(RdKeyNicknames, dto.NickName);

            response.Dto = _mapper.Map<UserRegisterResponseDto>(userEntity);
            response.RepoResponseType = RepoResponseType.Created;
            response.Success = true;

            return response;
        }

        public UserLoginRepoResponse Login(UserLoginRequestDto dto)
        {
            var response = new UserLoginRepoResponse()
            {
                Success = false
            };

            bool valid = DtoValidator.TryValidate<UserLoginRequestDto, UserLoginValidator>(dto, out string? errors);
            if (!valid)
            {
                response.ErrorMessage = errors;
                response.RepoResponseType = RepoResponseType.BadRequest;
                return response;
            }

            var userEntity = TryGetUser(dto.Email, out string errorMessage, out RepoResponseType responseType);

            if (userEntity == null)
            {
                response.ErrorMessage = errorMessage;
                response.RepoResponseType = responseType;
                return response;
            }

            if (!CryptoHelper.VerifyPasswordHash(dto.Password, userEntity.PasswordHash, userEntity.PasswordSalt))
            {
                response.ErrorMessage = ErrMsgWrongEmailOrPass;
                response.RepoResponseType = RepoResponseType.BadRequest;
                return response;
            }

            CalculateBonus(userEntity);

            response.Dto = _mapper.Map<UserLoginResponseDto>(userEntity);
            response.RepoResponseType = RepoResponseType.Ok;
            response.Success = true;
            return response;
        }

        public UserVerifyRepoResponse Verify(UserVerifyRequestDto dto)
        {
            var response = new UserVerifyRepoResponse()
            {
                Success = false
            };

            bool valid = DtoValidator.TryValidate<UserVerifyRequestDto, UserVerifyValidator>(dto, out string? errors);
            if (!valid)
            {
                response.ErrorMessage = errors;
                response.RepoResponseType = RepoResponseType.BadRequest;
                return response;
            }

            var userEntity = TryGetUser(dto.Email, out string errorMessage, out RepoResponseType responseType);

            if (userEntity == null)
            {
                response.ErrorMessage = errorMessage;
                response.RepoResponseType = responseType;
                return response;
            }

            bool validToken = dto.VerificationToken == userEntity.VerificationToken;
            if (!validToken)
            {
                response.ErrorMessage = ErrMsgInvalidToken;
                response.RepoResponseType = RepoResponseType.BadRequest;
                return response;
            }

            bool alreadyVerified = userEntity.VerifiedDate != null;
            if (alreadyVerified)
            {
                response.ErrorMessage = ErrMsgEmailAlreadyVerified;
                response.RepoResponseType = RepoResponseType.BadRequest;
                return response;
            }

            userEntity.VerifiedDate = DateTime.UtcNow;
            var newJson = JsonSerializer.Serialize(userEntity);
            _db.HashSet(RdKeyUsers, dto.Email, newJson);

            response.Dto = _mapper.Map<UserVerifyResponseDto>(userEntity);
            response.RepoResponseType = RepoResponseType.Ok;
            response.Success = true;

            return response;
        }

        public UserForgotPasswordRepoResponse ForgotPassword(UserForgotPasswordRequestDto dto)
        {
            var response = new UserForgotPasswordRepoResponse()
            {
                Success = false
            };

            bool valid = DtoValidator.TryValidate<UserForgotPasswordRequestDto, UserForgotPasswordValidator>(dto, out string? errors);
            if (!valid)
            {
                response.ErrorMessage = errors;
                response.RepoResponseType = RepoResponseType.BadRequest;
                return response;
            }

            var userEntity = TryGetUser(dto.Email, out string errorMessage, out RepoResponseType responseType);

            if (userEntity == null)
            {
                response.ErrorMessage = errorMessage;
                response.RepoResponseType = responseType;
                return response;
            }

            userEntity.PasswordResetToken = CreateRandomToken();
            userEntity.ResetTokenExpirationDate = DateTime.UtcNow.AddMinutes(10);

            var userJson = JsonSerializer.Serialize(userEntity);
            _db.HashSet(RdKeyUsers, dto.Email, userJson);

            response.Dto = _mapper.Map<UserForgotPasswordResponseDto>(userEntity);
            response.RepoResponseType = RepoResponseType.Ok;
            response.Success = true;

            return response;
        }

        public UserResetPasswordRepoResponse ResetPassword(UserResetPasswordRequestDto dto)
        {
            var response = new UserResetPasswordRepoResponse()
            {
                Success = false
            };

            bool valid = DtoValidator.TryValidate<UserResetPasswordRequestDto, UserResetPasswordValidator>(dto, out string? errors);
            if (!valid)
            {
                response.ErrorMessage = errors;
                response.RepoResponseType = RepoResponseType.BadRequest;
                return response;
            }

            var userEntity = TryGetUser(dto.Email, out string errorMessage, out RepoResponseType responseType);

            if (userEntity == null)
            {
                response.ErrorMessage = errorMessage;
                response.RepoResponseType = responseType;
                return response;
            }

            bool validToken = dto.PasswordResetToken == userEntity.PasswordResetToken;
            if (!validToken)
            {
                response.ErrorMessage = ErrMsgInvalidToken;
                response.RepoResponseType = RepoResponseType.BadRequest;
                return response;
            }

            bool tokenExpired = userEntity.ResetTokenExpirationDate < DateTime.UtcNow;
            if (tokenExpired)
            {
                response.ErrorMessage = ErrMsgTokenExpired;
                response.RepoResponseType = RepoResponseType.BadRequest;
                return response;
            }

            CryptoHelper.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] salt);
            userEntity.PasswordHash = passwordHash;
            userEntity.PasswordSalt = salt;
            userEntity.PasswordResetToken = null;
            userEntity.ResetTokenExpirationDate = null;

            var newJson = JsonSerializer.Serialize(userEntity);
            _db.HashSet(RdKeyUsers, dto.Email, newJson);

            response.Dto = _mapper.Map<UserResetPasswordResponseDto>(userEntity);
            response.RepoResponseType = RepoResponseType.Ok;
            response.Success = true;

            return response;
        }
    }
}

using AutoMapper;
using TicTacToeSharedLib.Models.Dtos;
using TicTacToeSharedLib.Models.Entities;

namespace TicTacToeApi.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserRegisterRequestDto, UserEntity>();
            CreateMap<UserEntity, UserLoginResponseDto>();
            CreateMap<UserEntity, UserRegisterResponseDto>();
            CreateMap<UserEntity, UserVerifyResponseDto>();
            CreateMap<UserEntity, UserForgotPasswordResponseDto>();
            CreateMap<UserEntity, UserResetPasswordResponseDto>();
        }
    }
}

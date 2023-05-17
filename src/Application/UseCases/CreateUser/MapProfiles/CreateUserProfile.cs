using Application.UseCases.CreateUser.Dtos;
using AutoMapper;
using Domain.Entities.Common;

namespace Application.UseCases.CreateUser.MapProfiles
{
    public class CreateUserProfile : Profile
    {
        public CreateUserProfile()
        {
            CreateMap<CreateUserDto, Group>();
        }
    }
}

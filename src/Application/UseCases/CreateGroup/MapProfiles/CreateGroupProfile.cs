using Application.UseCases.CreateGroup.Dtos;
using AutoMapper;
using Domain.Entities.Common;

namespace Application.UseCases.CreateGroup.MapProfiles
{
    public class CreateGroupProfile : Profile
    {
        public CreateGroupProfile()
        {
            CreateMap<CreateGroupDto, Group>();
        }
    }
}

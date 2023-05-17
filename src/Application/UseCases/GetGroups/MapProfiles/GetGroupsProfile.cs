using Application.UseCases.GetGroups.Dtos;
using AutoMapper;
using Domain.Entities.Common;

namespace Application.UseCases.GetGroups.MapProfiles
{
    public class GetGroupsProfile : Profile
    {
        public GetGroupsProfile()
        {
            CreateMap<Group, GetGroupsDto>();
        }
    }
}

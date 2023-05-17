using Application.UseCases.GetGroupByUuid.Dtos;
using AutoMapper;
using Domain.Entities.Common;

namespace Application.UseCases.CreateGroup.MapProfiles
{
    public class GetGroupByUuidProfile : Profile
    {
        public GetGroupByUuidProfile()
        {
            CreateMap<Group, GetGroupByUuidDto>();
        }
    }
}

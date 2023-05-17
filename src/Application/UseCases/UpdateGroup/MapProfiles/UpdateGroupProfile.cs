using Application.UseCases.UpdateGroup.Dtos;
using AutoMapper;
using Domain.Entities.Common;

namespace Application.UseCases.UpdateGroup.MapProfiles
{
    public class UpdateGroupProfile : Profile
    {
        public UpdateGroupProfile()
        {
            CreateMap<UpdateGroupDto, Group>();
        }
    }
}

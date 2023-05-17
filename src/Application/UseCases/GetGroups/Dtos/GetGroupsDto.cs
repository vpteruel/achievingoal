using Application.UseCases.Common;

namespace Application.UseCases.GetGroups.Dtos
{
    public class GetGroupsDto : BaseDto
    {
        public string Name { get; set; }
        public string Alias { get; set; }
    }
}

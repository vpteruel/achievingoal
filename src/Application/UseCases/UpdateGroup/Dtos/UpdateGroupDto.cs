using Application.UseCases.Common;

namespace Application.UseCases.UpdateGroup.Dtos
{
    public class UpdateGroupDto : BaseDto
    {
        public string Name { get; set; }
        public string Alias { get; set; }
    }
}

using Application.UseCases.Common;

namespace Application.UseCases.CreateGroup.Dtos
{
    public class CreateGroupDto : BaseDto
    {
        public string Name { get; set; }
        public string Alias { get; set; }
    }
}

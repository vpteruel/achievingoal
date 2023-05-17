using Application.UseCases.Common;

namespace Application.UseCases.GetGroupByUuid.Dtos
{
    public class GetGroupByUuidDto : BaseDto
    {
        public string Name { get; set; }
        public string Alias { get; set; }
    }
}

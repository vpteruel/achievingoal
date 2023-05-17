using Application.UseCases.Common;

namespace Application.UseCases.CreateUser.Dtos
{
    public class CreateUserDto : BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }

        public int GroupId { get; set; }
    }
}

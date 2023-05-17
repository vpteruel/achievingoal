namespace Domain.Entities.Common
{
    public class User : BaseEntity
    {
        public bool IsAdmin { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string? Password { get; private set; }
        public string? PhoneNumber { get; private set; }
        public DateTime? Birthday { get; private set; }

        public int GroupId { get; private set; }
        public virtual Group Group { get; private set; }

        public User(string name, string email) : base()
        {
            IsAdmin = false;
            Name = name;
            Email = email;
        }
    }
}

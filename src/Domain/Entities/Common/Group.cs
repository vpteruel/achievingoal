namespace Domain.Entities.Common
{
    public class Group : BaseEntity
    {
        public string Name { get; private set; }
        public string Alias { get; private set; }

        public virtual ICollection<User> Users { get; private set; }

        public Group(string name, string alias) : base()
        {
            Name = name;
            Alias = alias;
            Users = new HashSet<User>();
        }

        public void ChangeNameAndAlias(string name, string alias)
        {
            Name = name;
            Alias = alias;
        }
    }
}

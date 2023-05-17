using Domain.Entities.Kanban.Enums;

namespace Domain.Entities.Kanban
{
    public class Borad : BaseEntity
    {
        public string Name { get; private set; }
        public EBoardType Type { get; private set; }

        public virtual ICollection<Task> Tasks { get; private set; }

        public Borad(string name, EBoardType type)
        {
            Name = name;
            Type = type;
            Tasks = new HashSet<Task>();
        }
    }
}

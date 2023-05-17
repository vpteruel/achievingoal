using Domain.Entities.Kanban.Enums;

namespace Domain.Entities.Kanban
{
    public class Task : BaseEntity
    {
        public string Title { get; private set; }
        public ETaskStatus Status { get; private set; }

        public Borad Board { get; private set; }

        public Task(string title, ETaskStatus status, Borad board)
        {
            Title = title;
            Status = status;
            Board = board;
        }
    }
}

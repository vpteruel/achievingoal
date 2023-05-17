namespace Domain.Entities.Gtd
{
    public class Task : BaseEntity
    {
        public string Title { get; private set; }

        public Task(string title)
        {
            Title = title;
        }
    }
}

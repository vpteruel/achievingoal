namespace Domain.Entities.Okr
{
    public class Objective : BaseEntity
    {
        public string Title { get; private set; }

        public virtual ICollection<KeyResult> KeyResults { get; private set; }

        public Objective(string title)
        {
            Title = title;
            KeyResults = new HashSet<KeyResult>();
        }
    }
}

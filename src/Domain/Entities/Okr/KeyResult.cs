namespace Domain.Entities.Okr
{
    public class KeyResult : BaseEntity
    {
        public string Title { get; private set; }

        public Objective Objective { get; private set; }

        public KeyResult(string title, Objective objective)
        {
            Title = title;
            Objective = objective;
        }
    }
}

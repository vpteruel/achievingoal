using System.Diagnostics;

namespace Domain.Entities
{
    [DebuggerDisplay("Id = {Id}")]
    public abstract class BaseEntity
    {
        public int Id { get; private set; }
        public Guid Uuid { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public int Deleted { get; private set; }

        public BaseEntity()
        {
            Uuid = Guid.NewGuid();
            CreatedAt = DateTimeOffset.UtcNow;
            Deleted = 0;
        }
    }
}

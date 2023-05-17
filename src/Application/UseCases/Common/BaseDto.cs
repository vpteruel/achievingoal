using System.Diagnostics;

namespace Application.UseCases.Common
{
    [DebuggerDisplay("Uuid = {Uuid}")]
    public abstract class BaseDto
    {
        public Guid Uuid { get; set; }
    }
}

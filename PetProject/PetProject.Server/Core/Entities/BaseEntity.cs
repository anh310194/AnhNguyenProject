using System.Numerics;

namespace PetProject.Server.Core.Entities
{
    public abstract class BaseEntity
    {
        public required long Id { get; set; }
        public required DateTime CreatedTime { get; set; }
        public required long CreatedId { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public long UpdatedId { get; set; }
        public required byte[] RowVersion { get; set; }

    }
}

using PetProject.Server.Core.Enums;

namespace PetProject.Server.Core.Entities
{
    public class MasterData: BaseEntity
    {        
        public required string Name { get; set; }
        public string? Description { get; set; }
        public long? ParentId { get; set; }
        public bool IsDeleted { get; set; }
        public MasterDataType Type { get; set; }

    }
}

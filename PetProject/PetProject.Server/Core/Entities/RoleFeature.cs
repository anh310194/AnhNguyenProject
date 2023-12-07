namespace PetProject.Server.Core.Entities
{
    public class RoleFeature : BaseEntity
    {
        public long RoleId { get; set; }
        public long FeatureId { get; set; }
        public bool IsDeleted { get; set; }
    }
}

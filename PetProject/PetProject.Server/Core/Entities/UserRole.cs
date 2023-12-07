namespace PetProject.Server.Core.Entities
{
    public class UserRole : BaseEntity
    {
        public long RoleId { get; set; }
        public long UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}

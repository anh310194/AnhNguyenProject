using PetProject.Server.Core.Enums;

namespace PetProject.Server.Core.Entities
{
    public class User : BaseEntity
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Password { get; set; }
        public string? SaltPassword { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public long CountryId { get; set; }
        public long StateId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ZipCode { get; set; }
        public long DateTimeFormatId { get; set; }
        public long TimeFormatId { get; set; }
        public long TimeZoneId { get; set; }
        public UserType UserType { get; set; }
        public EnumStatus Status { get; set; }
        public bool IsLock { get; set; }
        public DateTime? ExpireTimeLock { get; set; }
        public int CountFailSignIn { get; set; }

    }
}

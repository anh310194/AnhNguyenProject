using PetProject.Server.Core.Entities;

namespace PetProject.Server.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Feature> FeatureRepository { get; }
        IRepository<MasterData> MasterDataRepository { get; }
        IRepository<Role> RoleRepository { get; }
        IRepository<RoleFeature> RoleFeatureRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<UserRole> UserRoleRepository { get; }
        int SaveChanges();
        ValueTask SaveChangesAsync();
    }
}

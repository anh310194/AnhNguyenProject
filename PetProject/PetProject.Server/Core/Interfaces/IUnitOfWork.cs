using PetProject.Server.Core.Entities;

namespace PetProject.Server.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
        Task SaveChangesAsync();
    }
}

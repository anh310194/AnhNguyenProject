using PetProject.Server.Core.Entities;
using PetProject.Server.Core.Interfaces;

namespace PetProject.Server.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private Dictionary<string, dynamic> dictionaryRepository;
        private readonly PetProjectContext _context;
        public UnitOfWork(PetProjectContext context) {
            _context = context;
            dictionaryRepository = new Dictionary<string, dynamic>();
        }

        private dynamic GetRepository<TEntity>(string entityName) where TEntity : BaseEntity
        {
            var repository = dictionaryRepository[entityName];
            if (repository == null)
            {
                repository = new Repository<TEntity>(_context);
                dictionaryRepository.Add(entityName, repository);

            }
            return repository;
        }

        public IRepository<Feature> FeatureRepository
        {
            get
            {
                return GetRepository<Feature>(typeof(Feature).Name);
            }
        }

        public IRepository<MasterData> MasterDataRepository
        {
            get
            {
                return GetRepository<MasterData>(typeof(MasterData).Name);
            }
        }

        public IRepository<Role> RoleRepository
        {
            get
            {
                return GetRepository<Role>(typeof(Role).Name);
            }
        }

        public IRepository<RoleFeature> RoleFeatureRepository
        {
            get
            {
                return GetRepository<RoleFeature>(typeof(RoleFeature).Name);
            }
        }

        public IRepository<User> UserRepository
        {
            get
            {
                return GetRepository<User>(typeof(User).Name);
            }
        }

        public IRepository<UserRole> UserRoleRepository
        {
            get
            {
                return GetRepository<UserRole>(typeof(UserRole).Name);
            }
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public ValueTask SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}

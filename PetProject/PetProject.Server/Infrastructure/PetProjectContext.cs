using Microsoft.EntityFrameworkCore;

namespace PetProject.Server.Infrastructure
{
    public class PetProjectContext: DbContext
    {
        public PetProjectContext(DbContextOptions<PetProjectContext> options)
            : base(options)
        {
        }
    }
}

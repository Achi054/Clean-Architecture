using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Persistence
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
            
        }
    }
}

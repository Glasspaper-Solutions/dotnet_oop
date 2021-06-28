using Microsoft.EntityFrameworkCore;

namespace BasicWebApi.Data
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options)
            : base(options)
        {
        }

        public DbSet<PersonEntity> PersonSet { get; set; }
    }
}
namespace firstlab.Models
{
    using Microsoft.EntityFrameworkCore;

    public class DB : DbContext
    {
        public DbSet<Person> Persons { get; set; } = null!;

        public DB()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=54321;Database=personsdb;Username=postgres;Password=password");
        }
    }
}

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
            optionsBuilder.UseNpgsql("Host=ec2-44-207-133-100.compute-1.amazonaws.com;Port=5432;Database=db8qdjfjmmm786;Username=rkbinbvglsjdly;Password=b8ef7c98a29d2f0d4f4f1ce65ec960d2f07e64dca5bc435ff6a94a169022fb33");
        }
    }
}

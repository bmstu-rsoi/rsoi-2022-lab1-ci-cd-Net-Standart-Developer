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
            optionsBuilder.UseNpgsql("Host=ec2-44-207-253-50.compute-1.amazonaws.com;Port=5432;Database=d93fsgtjvb8mhk;Username=sjhddzjabbauqx;Password=bb6f83ffedf446505e75867d9fdb3ea394b341d143ca284e7fcdbbba32a1ce13");
        }
    }
}

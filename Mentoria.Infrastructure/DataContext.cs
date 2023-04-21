using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Mentoria.Infrastructure
{
    public class DataContext : DbContext
    {
        public DbSet<CustomerEntity>? Customers { get; set; }

        public DataContext():base()
        {
            
        }
      
        public DataContext(DbContextOptions options) : base(options)
        {
          
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           

            //optionsBuilder.UseSqlite("Data Source=mydb.db");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
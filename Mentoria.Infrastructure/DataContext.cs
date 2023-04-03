using Microsoft.EntityFrameworkCore;

namespace Mentoria.Infrastructure
{
    public class DataContext : DbContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }
    }
}
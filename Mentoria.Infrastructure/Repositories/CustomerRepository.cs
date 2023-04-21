namespace Mentoria.Infrastructure.Repositories;

public class CustomerRepository:BaseRepository<CustomerEntity> {
    public CustomerRepository(DataContext db) : base(db)
    {
    }
}
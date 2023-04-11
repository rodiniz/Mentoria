namespace Mentoria.Infrastructure
{
    public class CustomerEntity:BaseEntity
    {     

        public string? FirstName { get; set; }

        public string? SurName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}

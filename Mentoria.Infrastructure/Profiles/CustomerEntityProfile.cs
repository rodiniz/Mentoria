using AutoMapper;
using Mentoria.Domain;

namespace Mentoria.Infrastructure.Profiles;

public class CustomerEntityProfile:Profile
{
    public CustomerEntityProfile()
    {
        CreateMap<CustomerEntity, Customer>()
            .ReverseMap();
    }
}
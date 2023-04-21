using AutoMapper;
using Mentoria.Application.Dtos;
using Mentoria.Domain;

namespace Mentoria.Application.Profiles;

public class CustomerProfile:Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDto>()
            .ReverseMap();
    }
}
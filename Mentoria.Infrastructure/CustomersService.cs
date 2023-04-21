using AutoMapper;
using FluentValidation;
using Mentoria.Application;
using Mentoria.Domain;
using Mentoria.Infrastructure.Repositories;
using OneOf;
using OneOf.Types;

namespace Mentoria.Infrastructure;

public class CustomersService : ICrudService<Customer>
{
    private readonly IValidator<Customer> _validator;
    private readonly IRepository<CustomerEntity?> _repository;

    private readonly IMapper _mapper;

    public CustomersService(
        IValidator<Customer> validator, 
        IRepository<CustomerEntity?> repository,
        IMapper mapper)
    {
        _validator = validator;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<OneOf<Customer, ValidationFailed>> Create(Customer obj)
    {
        var validationResult = await _validator.ValidateAsync(obj);
        if(!validationResult.IsValid){
            return new ValidationFailed(validationResult.Errors);
        }
        var inserted= await _repository.Add(_mapper.Map<CustomerEntity>(obj));
        return _mapper.Map<Customer>(inserted);
    }

    public async Task Delete(int id)
    {
      
        await _repository.Remove(id);
    }

    public async Task<Customer> GetAsync(int id)
    {
        return _mapper.Map<Customer>(await _repository.GetById(id));
    }

    public List<Customer> Get(int currentPage, int pageSize)
    {
        throw new NotImplementedException();
    }

    public int TotalCount()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Customer>> GetAll()
    {
        var results= (await _repository.GetAll()).ToList();
        return _mapper.Map<List<Customer>>(results);
    }

    public async Task<OneOf<Customer, NotFound, ValidationFailed>> UpdateAsync(Customer obj)
    {
        var entity=await _repository.GetById(obj.Id);
        if(entity==null){
            return new NotFound();
        }
        var validationResult = await _validator.ValidateAsync(obj);
        if(!validationResult.IsValid){
            return new ValidationFailed(validationResult.Errors);
        }
        entity = _mapper.Map<CustomerEntity>(obj);
        await _repository.Update(entity);

        return _mapper.Map<Customer>(entity);
    }
}
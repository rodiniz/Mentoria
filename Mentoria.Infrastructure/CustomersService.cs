using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Mentoria.Application;
using Mentoria.Domain;
using Mentoria.Infrastructure;
using OneOf;

public class CustomersService : ICrudService<Customer>
{
    private readonly IValidator<Customer> _validator;
    private readonly IRepository<CustomerEntity> _repository;

    private readonly IMapper _mapper;

    public CustomersService(IValidator<Customer> validator, IRepository<CustomerEntity> repository, IMapper mapper)
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

        return obj;
    }

    public async Task Delete(Customer obj)
    {
        var entity= _mapper.Map<CustomerEntity>(obj);
        await _repository.Remove(entity);
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

    public async Task<OneOf<Customer, NotFound, ValidationFailed>> UpdateAsync(Customer obj)
    {
        CustomerEntity entity=await _repository.GetById(obj.Id);
        if(entity==null){
            return new NotFound();
        }
        var validationResult = await _validator.ValidateAsync(obj);
        if(!validationResult.IsValid){
            return new ValidationFailed(validationResult.Errors);
        }

        await _repository.Update(entity);

        return _mapper.Map<Customer>(entity);
    }
}
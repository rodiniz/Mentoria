using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Mentoria.Domain;
using Mentoria.Infrastructure.Repositories;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using OneOf.Types;

namespace Mentoria.Infrastructure.Tests;

public class CustomerServiceTests
{
    private readonly IMapper _mapper;
    private readonly Fixture _fixture;
    private readonly IValidator<Customer> _validator;
    private readonly IRepository<CustomerEntity?> _repository;
    public CustomerServiceTests()
    {
        _validator = Substitute.For<IValidator<Customer>>();
        _repository = Substitute.For<IRepository<CustomerEntity?>>();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CustomerEntity, Customer>();
            cfg.CreateMap<Customer, CustomerEntity>();
        });
        _mapper = config.CreateMapper();
        _fixture = new Fixture();
        _fixture.Customize(new AutoNSubstituteCustomization());
    }
    [Fact]
    public async Task Should_Create_Customer()
    {
        // Arrange
        _validator.ValidateAsync(Arg.Any<Customer>(), default)
            .Returns(new ValidationResult());
        var service = new CustomersService(_validator, _repository, _mapper);
        var customer = _fixture.Create<Customer>();

        // Act
        var result = await service.Create(customer);

        // Assert
        await _repository.Received().Add(Arg.Any<CustomerEntity>());
        result.IsT0.Should().BeTrue();
        var customerResult = result.AsT0;
        
        customerResult.Should().BeEquivalentTo(customer);
    }

    [Fact]
    public async Task Should_ReturnValidationFailed()
    {
        // Arrange
        var validationResult = new ValidationResult(new[]
        {
            new ValidationFailure("Name", "Name is required")
        });
        
        _validator.ValidateAsync(Arg.Any<Customer>(), default).Returns(validationResult);
        var service = new CustomersService(_validator, _repository, _mapper);
        var customer = _fixture.Create<Customer>();

        // Act
        var result = await service.Create(customer);

        // Assert
        result.IsT1.Should().BeTrue();
        await _repository.DidNotReceive().Add(Arg.Any<CustomerEntity>());
    }
    
    [Fact]
    public async Task Should_Update_Customer()
    {
        // Arrange
        var id = _fixture.Create<int>();
        var customerEntity = _fixture.Build<CustomerEntity>()
                .With(c => c.Id, id)
                .Create();
        _validator.ValidateAsync(Arg.Any<Customer>(), default)
            .Returns(new ValidationResult());
        _repository.GetById(id).Returns(customerEntity);
        var service = new CustomersService(_validator, _repository, _mapper);
        var customer = _fixture.Build<Customer>()
            .With(c => c.Id, id)
            .Create();

        // Act
        var result = await service.UpdateAsync(customer);

        // Assert
        await _repository.Received().Update(Arg.Any<CustomerEntity>());
        result.IsT0.Should().BeTrue();
        result.AsT0.Should().BeEquivalentTo(customer);
    }
    
    [Fact]
    public async Task Should_ReturnNotFound_When_EntityIsNotOnDatabase()
    {
        // Arrange
        var id = _fixture.Create<int>();
        _validator.ValidateAsync(Arg.Any<Customer>(), default)
            .Returns(new ValidationResult());
        _repository.GetById(id).ReturnsNull();
        var service = new CustomersService(_validator, _repository, _mapper);
        var customer = _fixture.Build<Customer>()
            .With(c => c.Id, id)
            .Create();

        // Act
        var result = await service.UpdateAsync(customer);

        // Assert
        result.IsT1.Should().BeTrue();
        result.AsT1.Should().BeOfType<NotFound>();
    }
}
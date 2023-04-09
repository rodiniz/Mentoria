using FluentValidation;
using Mentoria.Domain;
public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(customer => customer.FirstName).NotNull();
        RuleFor(customer => customer.Email).NotNull().EmailAddress();
    }
}
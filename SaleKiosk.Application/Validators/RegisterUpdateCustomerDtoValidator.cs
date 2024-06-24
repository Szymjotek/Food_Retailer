using FluentValidation;
using SaleKiosk.SharedKernel.Dto;

namespace SaleKiosk.Application.Validators
{
    public class RegisterUpdateCustomerDtoValidator : AbstractValidator<UpdateCustomerDto>
    {
        public RegisterUpdateCustomerDtoValidator()
        {
            RuleFor(p => p.CustomerName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(30);

            RuleFor(p => p.Address)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(p => p.PhoneNumber)
                .NotEmpty()
                .Length(9);


        }

    }
}

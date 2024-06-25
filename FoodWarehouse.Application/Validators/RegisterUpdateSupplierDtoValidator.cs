﻿using FluentValidation;
using FoodWarehouse.SharedKernel.Dto;

namespace FoodWarehouse.Application.Validators
{
    public class RegisterUpdateSupplierDtoValidator : AbstractValidator<UpdateSupplierDto>
    {
        public RegisterUpdateSupplierDtoValidator()
        {
            RuleFor(p => p.SupplierName)
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

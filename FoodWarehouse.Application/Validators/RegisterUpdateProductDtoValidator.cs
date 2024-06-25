﻿using FluentValidation;
using FoodWarehouse.SharedKernel.Dto;

namespace FoodWarehouse.Application.Validators
{
    public class RegisterUpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public RegisterUpdateProductDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(30);

            RuleFor(p => p.Desc)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(60);

            RuleFor(p => p.UnitPrice)
                .GreaterThan(0);

            
        }

    }
}

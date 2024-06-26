﻿using FluentValidation;
using SaleKiosk.Domain.Contracts;
using SaleKiosk.SharedKernel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleKiosk.Application.Validators
{
    public class RegisterCreateSupplierDtoValidator : AbstractValidator<CreateSupplierDto>
    {
        //public RegisterCreateProductDtoValidator()
        //{
        //    RuleFor(p => p.Name)
        //        .NotEmpty()
        //        .MinimumLength(2)
        //        .MaximumLength(20);

        //    RuleFor(p => p.Desc)
        //        .NotEmpty()
        //        .MinimumLength(2)
        //        .MaximumLength(20);

        //    RuleFor(p => p.UnitPrice)
        //        .GreaterThan(0);
        //}

        public RegisterCreateSupplierDtoValidator(IFoodWarehouseUnitOfWork unitOfWork)
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
                .Length(9)
                .NotEmpty();

     
        }

    }
}

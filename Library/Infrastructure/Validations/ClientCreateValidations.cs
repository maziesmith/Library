using FluentValidation;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Infrastructure.Validations
{
    public class ClientCreateValidations :AbstractValidator<ClientViewModel>
    {
        public ClientCreateValidations() { 
        RuleFor(x => x.Name).NotNull().Length(3, 20).WithMessage("Name is required!");
        RuleFor(x => x.City).NotNull().Length(3, 20).WithMessage("City is required!");
        RuleFor(x => x.Address).NotNull().Length(3,50).WithMessage("Address is required!");
        RuleFor(x => x.Phone).NotNull().WithMessage("Phone is required!");
        }
    }
}
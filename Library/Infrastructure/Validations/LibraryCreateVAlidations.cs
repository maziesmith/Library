using FluentValidation;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Infrastructure.Validations
{
    public class LibraryCreateVAlidations:AbstractValidator<LibraryViewModel>
    {
        public LibraryCreateVAlidations()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("ID is required!");
            RuleFor(x => x.City).NotNull().Length(3, 20).WithMessage("City is required and it must be shorter then 20 characters!");
            RuleFor(x => x.Address).NotNull().Length(3, 50).WithMessage("Address is required and it must be shorter then 50 characters!");
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required!");
        }

        

    }
}
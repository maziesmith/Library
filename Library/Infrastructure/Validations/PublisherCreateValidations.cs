using FluentValidation;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Infrastructure.Validations
{
    public class PublisherCreateValidations:AbstractValidator<PublisherViewModel>
    {
        public PublisherCreateValidations()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required!");
            RuleFor(x => x.Name).NotNull().Length(3, 20).WithMessage("Name is required and it must be shorter then 20 characters!");
            RuleFor(x => x.Country).NotNull().Length(3, 20).WithMessage("Country is required and it must be shorter then 20 characters!");
        }
    }
}
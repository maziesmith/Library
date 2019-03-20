using FluentValidation;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Infrastructure.Validations
{
    public class BookCreateValidations : AbstractValidator<BookViewModel>
    {
        public BookCreateValidations() 
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required!");
            RuleFor(x => x.NumberOfPages).NotNull().WithMessage("Number of Pages is required!");
            RuleFor(x => x.YearOfIssue).NotNull().WithMessage("Year of Issue is required!");
            RuleFor(x => x.Title).NotNull().Length(3, 50).WithMessage("Title is required and it must be shorter then 50 characters!");

        }
    }
}
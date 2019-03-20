using Domain;
using Library.Infrastructure.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    [FluentValidation.Attributes.Validator(typeof(BookCreateValidations))]
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public int YearOfIssue { get; set; }
        public int NumberOfPages { get; set; }
        public string Publisher { get; set; }
        public int LendingsNr { get; set; }
        public int BookNr { get; set; }

    }
    
}
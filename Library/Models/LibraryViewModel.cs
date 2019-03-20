using FluentValidation.Results;
using Library.Infrastructure.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    [FluentValidation.Attributes.Validator(typeof(LibraryCreateVAlidations))]
    public class LibraryViewModel
    {
        
        public int Id { get; set; }
        public string  Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int BookNr { get; set; }
    }
    
}
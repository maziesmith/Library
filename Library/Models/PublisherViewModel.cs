using Library.Infrastructure.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    [FluentValidation.Attributes.Validator(typeof(PublisherCreateValidations))]
    public class PublisherViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  string Country { get; set; }
        public int BookNr { get; set; }
    }
}
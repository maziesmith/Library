using Library.Infrastructure.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    [FluentValidation.Attributes.Validator(typeof(ClientCreateValidations))]
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public decimal Phone { get; set; }
        public int LendingsNr { get; set; }
    }
}
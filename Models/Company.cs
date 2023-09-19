using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = nameof(Name))]
        public string? Name { get; set; }

        [Display(Name = nameof(StreetAddress))]
        public string? StreetAddress { get; set; }

        [Display(Name = nameof(City))]
        public string? City { get; set; }

        [Display(Name = nameof(State))]
        public string? State { get; set; }

        [Display(Name = nameof(PostalCode))]
        public string? PostalCode { get; set; }

        [Display(Name = nameof(PhoneNumber))]
        public string? PhoneNumber { get; set; }
    }
}

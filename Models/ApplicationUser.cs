using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = nameof(FirstName))]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = nameof(LastName))]
        public string? LastName { get; set; }
        [Display(Name = nameof(StreetAddress))]
        public string? StreetAddress { get; set; }
        [Display(Name = nameof(City))]
        public string? City { get; set; }
        [Display(Name = nameof(State))]
        public string? State { get; set; }
        [Display(Name = nameof(PostalCode))]
        public string? PostalCode { get; set; }
        public int UsernameChangeLimit { get; set; } = 10;
        [Display(Name = nameof(ProfilePicture))]
        public byte[]? ProfilePicture { get; set; }
        [Display(Name = nameof(CompanyId))]
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        [ValidateNever]
        public Company? Company { get; set; }
        [NotMapped]
        [Display(Name = nameof(Role))]
        public string Role { get; set; }
    }
}

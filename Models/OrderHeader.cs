using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderHeader
    {
        public int Id { get; set; }

        [ValidateNever]
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public double? OrderTotal { get; set; } = 0;
        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public string? TrackingNumber { get; set; }
        public string? Carrier { get; set; }

        public DateTime PaymentDate { get; set; }
        public DateTime PaymentDueDate { get; set; }

        public string? SessionId { get; set; }
        public string? PaymentIntentId { get; set; }


        [Required]
        [Display(Name = nameof(Name))]
        public string? Name { get; set; }

        [Required]
        [Display(Name = nameof(PhoneNumber))]
        public string? PhoneNumber { get; set; }

        [Required]
        [Display(Name = nameof(StreetAddress))]
        public string? StreetAddress { get; set; }

        [Required]
        [Display(Name = nameof(City))]
        public string? City { get; set; }

        [Required]
        [Display(Name = nameof(State))]
        public string? State { get; set; }

        [Required]
        [Display(Name = nameof(PostalCode))]
        public string? PostalCode { get; set; }

    }
}

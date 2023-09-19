using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = nameof(Title))]
        public string? Title { get; set; }

        [Display(Name = nameof(Description))]
        public string? Description { get; set; }

        [Required]
        public string? ISBN { get; set; }

        [Required]
        [Display(Name = nameof(Author))]
        public string? Author { get; set; }

        [Required]
        [Display(Name= "List Price")]
        [Range(1, 1000)]
        public double? ListPrice { get; set; }

        [Required]
        [Display(Name = "Price for 1-50")]
        [Range(1, 1000)]
        public double? Price { get; set; }

        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 1000)]
        public double? Price50 { get; set; }

        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 1000)]
        public double? Price100 { get; set; }
        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        [Required]
        [Display(Name = nameof(IsPromotional))]
        public bool IsPromotional { get; set; }
        [NotMapped]
        public bool IsCompared { get; set; }
        [NotMapped]
        public bool IsWished { get; set; }
        [NotMapped]
        public bool IsHistored { get; set; }
    }
}

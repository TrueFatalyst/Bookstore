using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class WishListProduct
    {
        [Key, Column(Order = 0)]
        public string? UserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        [Key, Column(Order = 1)]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}

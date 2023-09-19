using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class ReviewsShoppingCartViewModel
    {
        public ShoppingCart? ShoppingCart { get; set; }
        public IEnumerable<Review>? Reviews { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class ProductCategoryiesViewModel
    {
        public Product? Product { get; set; }
        public IEnumerable<SelectListItem>? Categories { get; set; }
    }
}

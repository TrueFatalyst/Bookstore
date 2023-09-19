using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Models.ViewModels
{
    public class ProductsCategoriesViewModel
    {
        public IEnumerable<Product>? Products { get; set; }
        public PagedListViewModel? PagedListViewModel { get; set; }

        public IEnumerable<Category>? Categories { get; set; }
    }
}

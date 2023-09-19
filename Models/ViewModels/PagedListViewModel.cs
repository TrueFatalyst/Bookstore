using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using X.PagedList;

namespace Models.ViewModels
{
    public class PagedListViewModel
    {
        public IPagedList<Product> Products { get; set; }
        public string? CategoryId { get; set; }
        public string? SearchedValue { get; set; }
        public bool InWishList { get; set; }
        public SortOrder SortOrder { get; set; } = SortOrder.ByTitle;
    }
}

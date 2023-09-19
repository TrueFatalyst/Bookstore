using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using System.Security.Claims;
using Utility;

namespace Web.ViewComponents
{
    public class ProductCardViewComponent : ViewComponent
    {
        IUnitOfWork _unitOfWork;
        public ProductCardViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync(int productID)
        {
            var claimsIdentity = (ClaimsIdentity?)User.Identity;
            var userId = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var product = _unitOfWork.Product.Get(p => p.Id == productID, includeProperties: "Category");
            
            List<int> wishListIds = _unitOfWork.WishList.GetAll(p => p.UserId == userId).Select(p => p.ProductId).ToList();
            List<int> comparisonIds = HttpContext.Session.Get<List<int>>(SD.SessionCompare) ?? new List<int>();

            product.IsWished = wishListIds.Contains(product.Id);
            product.IsCompared = comparisonIds.Contains(product.Id);

            return View(product);
        }
    }
}

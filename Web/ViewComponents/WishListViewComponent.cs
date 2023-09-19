using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.ViewComponents
{
    public class WishListViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public WishListViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                var products = _unitOfWork.WishList.GetAll(p => p.UserId == userId);
                return View(products.Count());
            }
            else
            {
                return View(0);
            }
        }
    }
}

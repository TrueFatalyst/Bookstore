using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;
using Utility;

namespace Web.ViewComponents
{
    public class ComparisonViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public ComparisonViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<int>? comparisonIds = HttpContext.Session.Get<List<int>>(SD.SessionCompare) ?? new List<int>();

            return View(comparisonIds.Count);
        }

    }
}

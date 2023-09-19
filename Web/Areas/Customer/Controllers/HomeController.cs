using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Models;
using Models.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Claims;
using System.Text;
using Utility;
using X.PagedList;
using SortOrder = Utility.SortOrder;

namespace Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<HomeController>? _localizer;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IStringLocalizer<HomeController>? localizer)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public IActionResult Index(int? page)
        {
            IEnumerable<Product>? products = _unitOfWork?.Product?.GetAll(includeProperties: "Category");
            IEnumerable<Category>? categories = _unitOfWork?.Category?.GetAll();

            List<int> wishListIds = _unitOfWork.WishList.GetAll(p => p.UserId == GetUserId()).Select(p => p.ProductId).ToList();
            List<int> historyIds = HttpContext.Session.Get<List<int>>(SD.SessionHistory) ?? new List<int>();
            List<int> comparisonIds = HttpContext.Session.Get<List<int>>(SD.SessionCompare) ?? new List<int>();

            foreach (var product in products)
            {
                product.IsWished = wishListIds.Contains(product.Id);
                product.IsCompared = comparisonIds.Contains(product.Id);
                product.IsHistored = historyIds.Contains(product.Id);
            }

            products = GetSortedList(products, SortOrder.ByTitle);
            var pagedListProducts = GetPagedList(products, page);
            PagedListViewModel pagedListViewModel = new() { Products = pagedListProducts, CategoryId = null, SearchedValue = null, SortOrder = SortOrder.ByTitle };
            ProductsCategoriesViewModel productCategoryViewModel = new ProductsCategoriesViewModel { Products = products, Categories = categories, PagedListViewModel = pagedListViewModel };

            return View(productCategoryViewModel);
        }

        public IActionResult Details(int productId)
        {
            Product product = _unitOfWork?.Product?.Get(p => p.Id == productId, includeProperties: "Category");

            if (product is null)
                return NotFound();
            IEnumerable<Review>? reviews = _unitOfWork?.Review?.GetAll(r => r.ProductId == productId, includeProperties: "ApplicationUser");

            List<int> wishListIds = _unitOfWork.WishList.GetAll(p => p.UserId == GetUserId()).Select(p => p.ProductId).ToList();
            List<int> comparisonIds = HttpContext.Session.Get<List<int>>(SD.SessionCompare) ?? new List<int>();

            ShoppingCart shoppingCart = new()
            {
                Product = product,
                Count = 1,
                ProductId = productId,
                IsWished = wishListIds.Contains(productId),
                IsCompared = comparisonIds.Contains(productId)
            };

            ReviewsShoppingCartViewModel reviewsShoppingCartViewModel = new()
            {
                ShoppingCart = shoppingCart,
                Reviews = reviews
            };

            AddToHistory(productId);

            return View(reviewsShoppingCartViewModel);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var userId = GetUserId();
            shoppingCart.ApplicationUserId = userId;

            ShoppingCart? cartFromDb = _unitOfWork?.ShoppingCart?
                    .Get(u => u.ApplicationUserId == userId &&
                        u.ProductId == shoppingCart.ProductId);

            if (cartFromDb != null)
            {
                // shopping cart exists
                cartFromDb.Count += shoppingCart.Count;
                _unitOfWork?.ShoppingCart?.Update(cartFromDb);
                _unitOfWork?.Save();

            }
            else
            {
                // add cart record
                _unitOfWork?.ShoppingCart?.Add(shoppingCart);
                _unitOfWork?.Save();
                HttpContext.Session.SetInt32(SD.SessionCart, (int)_unitOfWork.ShoppingCart
                    .GetAll(u => u.ApplicationUserId == userId).Sum(p => p.Count));
            }

            //TempData["Success"] = _localizer["Cart Updated Successfully"];
            TempData["Success"] = "Cart Updated Successfully";

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Authorize]
        public IActionResult WishList()
        {
            var userId = GetUserId();
            var wishListProducts = _unitOfWork.WishList.GetAll(p => p.UserId == userId);

            List<Product> products = new();
            foreach (var item in wishListProducts)
            {
                var product = _unitOfWork.Product.Get(p => p.Id == item.ProductId, includeProperties: "Category");
                products.Add(product);
            }

            List<int> wishListIds = _unitOfWork.WishList.GetAll(p => p.UserId == userId).Select(p => p.ProductId).ToList();
            List<int> comparisonIds = HttpContext.Session.Get<List<int>>(SD.SessionCompare) ?? new List<int>();

            foreach (var product in products)
            {
                product.IsWished = wishListIds.Contains(product.Id);
                product.IsCompared = comparisonIds.Contains(product.Id);
            }
            var productsPagedList = GetPagedList(products, null);
            PagedListViewModel pagedListViewModel = new() { Products = productsPagedList, InWishList = true };
            return View(pagedListViewModel);
        }
        public IActionResult Comparison()
        {
            List<int> comparisonIds = HttpContext.Session.Get<List<int>>(SD.SessionCompare) ?? new List<int>();

            List<Product> products = new();
            foreach (var id in comparisonIds)
                products.Add(_unitOfWork.Product.Get(p => p.Id == id, includeProperties: "Category"));

            return View("Comparison", products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string? GetUserId()
        {
            var claimsIdentity = (ClaimsIdentity?)User.Identity;
            var userId = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId;
        }

        private static IPagedList<Product> GetPagedList(IEnumerable<Product> products, int? page)
        {
            int pageNumber = (page ?? 1);
            return products.ToPagedList(pageNumber, SD.cardsPerPage);
        }

        private static IEnumerable<Product> GetSortedList(IEnumerable<Product> products, SortOrder sortOrder)
        {
            products = sortOrder switch
            {
                SortOrder.ByPromo => products.OrderByDescending(p => p.IsPromotional),
                SortOrder.ByPriceAscending => products.OrderBy(p => p.Price),
                SortOrder.ByPriceDescending => products.OrderByDescending(p => p.Price),
                SortOrder.ByTitle => products.OrderBy(p => p.Title),
                _ => products.OrderBy(p => p.Title),
            };
            return products;
        }
        private void AddToHistory(int productId)
        {
            List<int> history = HttpContext.Session.Get<List<int>>(SD.SessionHistory) ?? new List<int>();

            if (!history.Contains(productId))
            {
                if (history.Count >= 10)
                    history.RemoveAt(history.Count - 1);
                history.Insert(0, productId);
            }
            HttpContext.Session.Set(SD.SessionHistory, history);
        }

        public IActionResult SetCulture(string id = "en")
        {
            string culture = id;
            Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(
            new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            TempData["Success"] = "Culture set to " + culture;
            return View("Privacy");
        }
        #region API CALLS 
        [HttpGet]
        public IActionResult GetPagedListItems(int? page, string? categoryId = null, string? searchedValue = null, bool inWishList = false, SortOrder sortOrder = SortOrder.ByTitle)
        {
            if (categoryId is not null)
                return GetProductByCategoryId(categoryId, page, sortOrder);
            if (searchedValue is not null)
                return GetSearchedProduct(searchedValue, page, sortOrder);
            List<Product>? products = new List<Product>();

            if (inWishList)
            {
                var wishListProducts = _unitOfWork.WishList.GetAll(p => p.UserId == GetUserId());

                foreach (var item in wishListProducts)
                {
                    var product = _unitOfWork.Product.Get(p => p.Id == item.ProductId, includeProperties: "Category");
                    products.Add(product);
                }
            }
            else
            {
                IEnumerable<Product> productsByData = _unitOfWork?.Product?.GetAll(includeProperties: "Category");
                productsByData = GetSortedList(productsByData, sortOrder);
                products = productsByData.ToList();
            }

            List<int> wishListIds = _unitOfWork.WishList.GetAll(p => p.UserId == GetUserId()).Select(p => p.ProductId).ToList();
            List<int> historyIds = HttpContext.Session.Get<List<int>>(SD.SessionHistory) ?? new List<int>();
            List<int> comparisonIds = HttpContext.Session.Get<List<int>>(SD.SessionCompare) ?? new List<int>();

            foreach (var product in products)
            {
                product.IsWished = wishListIds.Contains(product.Id);
                product.IsCompared = comparisonIds.Contains(product.Id);
                product.IsHistored = historyIds.Contains(product.Id);
            }
            var pagedProducts = GetPagedList(products, page);
            PagedListViewModel pagedListViewModel = new() { Products = pagedProducts, CategoryId = categoryId, SearchedValue = searchedValue, InWishList = inWishList, SortOrder = sortOrder };

            return PartialView("_BooksPartialView", pagedListViewModel);
        }
        [HttpPost]
        public IActionResult SetAppLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(
            new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return LocalRedirect(returnUrl);
        }
        [HttpGet]
        public IActionResult GetSearchedProduct(string searchValue, int? page = null, SortOrder sortOrder = SortOrder.ByTitle)
        {
            IEnumerable<Product> products;
            if (string.IsNullOrEmpty(searchValue))
                products = _unitOfWork.Product.GetAll();
            else
                products = _unitOfWork.Product.GetAll(p => p.Title.ToLower().Contains(searchValue) ||
                                                           p.Author.ToLower().Contains(searchValue));

            List<int> comparisonIds = HttpContext.Session.Get<List<int>>(SD.SessionCompare) ?? new List<int>();
            List<int> wishListIds = _unitOfWork.WishList.GetAll(p => p.UserId == GetUserId()).Select(p => p.ProductId).ToList();

            foreach (var product in products)
            {
                product.IsWished = wishListIds.Contains(product.Id);
                product.IsCompared = comparisonIds.Contains(product.Id);
            }
            products = GetSortedList(products, sortOrder);
            var pagedProducts = GetPagedList(products, page);
            PagedListViewModel pagedListViewModel = new() { Products = pagedProducts, CategoryId = null, SearchedValue = searchValue, SortOrder = sortOrder };

            return PartialView("_BooksPartialView", pagedListViewModel);
        }
        [HttpGet]
        public IActionResult GetProductByCategoryId(string categoryId, int? page = null, SortOrder sortOrder = SortOrder.ByTitle)
        {
            IEnumerable<Product> products;
            if (string.IsNullOrEmpty(categoryId))
                products = _unitOfWork.Product.GetAll();
            else
                products = _unitOfWork.Product.GetAll(p => p.CategoryId == Convert.ToInt32(categoryId));

            List<int> comparisonIds = HttpContext.Session.Get<List<int>>(SD.SessionCompare) ?? new List<int>();
            List<int> wishListIds = _unitOfWork.WishList.GetAll(p => p.UserId == GetUserId()).Select(p => p.ProductId).ToList();

            foreach (var product in products)
            {
                product.IsWished = wishListIds.Contains(product.Id);
                product.IsCompared = comparisonIds.Contains(product.Id);
            }

            products = GetSortedList(products, sortOrder);
            var pagedProducts = GetPagedList(products, page);
            PagedListViewModel pagedListViewModel = new() { Products = pagedProducts, CategoryId = categoryId, SearchedValue = null, SortOrder = sortOrder };

            return PartialView("_BooksPartialView", pagedListViewModel);
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddReview(string reviewStr)
        {
            var queryParam = QueryHelpers.ParseQuery(reviewStr);

            int productId = int.Parse(queryParam["ProductId"]);
            string applicationUserId = queryParam["ApplicationUserId"];
            string content = queryParam["Content"];
            int rating = int.Parse(queryParam["Rating"]);

            Review review = new()
            {
                DatePosted = DateTime.Now,
                ProductId = productId,
                Rating = rating,
                ApplicationUserId = applicationUserId,
                Content = content
            };

            _unitOfWork?.Review?.Add(review);
            _unitOfWork?.Save();

            var reviews = _unitOfWork.Review.GetAll(r => r.ProductId == review.ProductId, includeProperties: "ApplicationUser");
            return PartialView("_ReviewsList", reviews);
        }
        [HttpPost]
        public IActionResult AddToComparison(int productId)
        {
            List<int> comparisonIds = HttpContext.Session.Get<List<int>>(SD.SessionCompare) ?? new List<int>();

            if (!comparisonIds.Contains(productId))
                comparisonIds.Add(productId);

            HttpContext.Session.Set(SD.SessionCompare, comparisonIds);

            return ViewComponent("Comparison");
        }
        [HttpDelete]
        public IActionResult DeleteComparisonProduct(int id)
        {
            List<int> comparisonIds = HttpContext.Session.Get<List<int>>(SD.SessionCompare) ?? new List<int>();

            comparisonIds.Remove(id);

            if (comparisonIds.Count == 0)
                HttpContext.Session.Remove(SD.SessionCompare);
            else
                HttpContext.Session.Set(SD.SessionCompare, comparisonIds);

            return ViewComponent("Comparison");
        }
        [HttpPost]
        [Authorize]
        public IActionResult ToggleProductToWishList(int productId)
        {
            var userId = GetUserId();
            var product = _unitOfWork.WishList.Get(p => p.UserId == userId && p.ProductId == productId);

            if (product == null)
            {
                product = new WishListProduct() { ProductId = productId, UserId = userId };
                _unitOfWork.WishList.Add(product);
            }
            else
            {
                _unitOfWork.WishList.Remove(product);
            }
            _unitOfWork.Save();

            return ViewComponent("WishList");
        }
        [HttpPost]
        public IActionResult ClearHistory()
        {
            HttpContext.Session.Remove(SD.SessionHistory);

            return PartialView("_HistoryPartialView", new List<Product>());
        }
        [HttpGet]
        public IActionResult GetSortedPagedList(SortOrder sortedId, string? categoryId = null, string? searchedValue = null)
        {
            if (categoryId is not null)
                return GetProductByCategoryId(categoryId, sortOrder: sortedId);
            if (searchedValue is not null)
                return GetSearchedProduct(searchedValue, sortOrder: sortedId);
            IEnumerable<Product>? products = _unitOfWork?.Product?.GetAll(includeProperties: "Category");
            products = GetSortedList(products, sortedId);
            var pagedListProducts = GetPagedList(products, null);

            PagedListViewModel model = new PagedListViewModel() { Products = pagedListProducts, SortOrder = sortedId };

            return PartialView("_BooksPartialView", model);
        }
        #endregion
    }
}
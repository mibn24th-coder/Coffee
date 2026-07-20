using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models.EF;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly FoodContext _dbContext;

        public HomeController(FoodContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            // 1. Đếm số lượng sản phẩm (Nước & Kem)
            ViewBag.TotalProducts = _dbContext.Products != null
                ? await _dbContext.Products.CountAsync()
                : 0;

            // 2. Đếm số lượng đơn đặt hàng từ khách hàng
            ViewBag.TotalOrders = _dbContext.Orders != null
                ? await _dbContext.Orders.CountAsync()
                : 0;

            // 3. Đếm số lượng bài viết tin tức
            ViewBag.TotalNews = _dbContext.Articles != null
                ? await _dbContext.Articles.CountAsync()
                : 0;

            // 4. Đếm số lượng khách hàng mua hàng thực tế (bảng Customers)
            ViewBag.TotalCustomers = _dbContext.Customers != null
                ? await _dbContext.Customers.CountAsync()
                : 0;

            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Core.Database.Models;
using Web.Models.EF; // Đảm bảo đúng namespace chứa FoodContext của bạn
using Web.Areas.Admin.Extensions; // Để dùng được hàm GetObject

namespace Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly FoodContext _context;

        public OrderController(FoodContext context)
        {
            _context = context;
        }
        // Đổi tên từ MyOrders thành History
        public IActionResult History()
        {
            var customer = HttpContext.Session.GetObject<Customer>("customer");

            if (customer == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var myOrders = _context.Orders
                                   .Where(o => o.CustomerId == customer.Id)
                                   .OrderByDescending(o => o.CreatedOn)
                                   .ToList();

            return View(myOrders); // Nó sẽ tự tìm file History.cshtml trong thư mục Views/Order
        }
        public IActionResult Details(Guid id)
        {
            var customer = HttpContext.Session.GetObject<Customer>("customer");
            if (customer == null) return RedirectToAction("Login", "Account");

            // Thay đổi ở đây: Include thêm các dữ liệu nếu cần
            var order = _context.Orders
                                .FirstOrDefault(o => o.Id == id && o.CustomerId == customer.Id);

            if (order == null) return NotFound();

            // Lấy chi tiết đơn hàng
            var orderDetails = _context.Set<Core.Database.Models.Details>()
                                       .Include(d => d.Product)
                                       .Where(d => d.OrderId == id)
                                       .ToList();

            ViewBag.OrderDetails = orderDetails;
            ViewBag.Customer = customer;

            // Lúc này 'order' đã có đủ DiscountAmount và DiscountCode vì EF tự động load
            return View(order);
        }
    }
}
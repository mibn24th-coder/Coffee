using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Web.Models.EF;
using Core.Database.Models;
using Web.Models;
using Web.Areas.Admin.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class CartController : Controller
    {
        private readonly FoodContext _context;

        public CartController(FoodContext context)
        {
            _context = context;
        }

        public IActionResult Add(Guid id)
        {
            var customer = HttpContext.Session.GetObject<Customer>("customer");

            if (customer == null)
            {
                return Json(new
                {
                    success = false,
                    login = true,
                    message = "Mời bạn đăng nhập tài khoản để rinh sản phẩm vào giỏ hàng ❤️"
                });
            }
            var product = _context.Products
                                  .FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var cart = HttpContext.Session.GetString("Cart");

            List<CartItem> carts;

            if (string.IsNullOrEmpty(cart))
            {
                carts = new List<CartItem>();
            }
            else
            {
                carts = JsonConvert.DeserializeObject<List<CartItem>>(cart)
                        ?? new List<CartItem>();
            }

            var item = carts.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                carts.Add(new CartItem()
                {
                    Id = product.Id,
                    Title = product.Title,
                    Picture = product.Picture,
                    Price = product.Price ?? 0,
                    Quantity = 1
                });
            }

            HttpContext.Session.SetString(
                "Cart",
                JsonConvert.SerializeObject(carts)
            );

            return Json(new
            {
                success = true
            });
        }

        public IActionResult Increase(Guid id)
        {
            var cart = HttpContext.Session.GetString("Cart");

            if (cart == null)
                return RedirectToAction("Index");

            var carts = JsonConvert.DeserializeObject<List<CartItem>>(cart)
             ?? new List<CartItem>();
            if (!carts.Any())
            {
                return RedirectToAction("Index");
            }

            var item = carts.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                item.Quantity++;
            }

            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(carts));

            return RedirectToAction("Index");
        }

        public IActionResult Decrease(Guid id)
        {
            var cart = HttpContext.Session.GetString("Cart");

            if (cart == null)
                return RedirectToAction("Index");

            var carts = JsonConvert.DeserializeObject<List<CartItem>>(cart)
            ?? new List<CartItem>();

            var item = carts.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                item.Quantity--;

                if (item.Quantity <= 0)
                {
                    carts.Remove(item);
                }
            }

            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(carts));

            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            var cart = HttpContext.Session.GetString("Cart");

            if (cart == null)
                return RedirectToAction("Index");
            var carts = JsonConvert.DeserializeObject<List<CartItem>>(cart)
                        ?? new List<CartItem>();

            var item = carts.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                carts.Remove(item);
            }

            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(carts));

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetString("Cart");

            if (cart == null)
            {
                return View(new List<CartItem>());
            }

            var carts = JsonConvert.DeserializeObject<List<CartItem>>(cart)
             ?? new List<CartItem>();

            return View(carts);
        }

        public IActionResult GetCount()
        {
            var cart = HttpContext.Session.GetString("Cart");

            if (string.IsNullOrEmpty(cart))
                return Json(0);

            var carts = JsonConvert.DeserializeObject<List<CartItem>>(cart)
            ?? new List<CartItem>();

            return Json(carts.Count());
        }

        public IActionResult Checkout()
        {
            var customer = HttpContext.Session.GetObject<Customer>("customer");

            if (customer == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var cart = HttpContext.Session.GetString("Cart");

            if (string.IsNullOrEmpty(cart))
                return RedirectToAction("Index");

            var carts = JsonConvert.DeserializeObject<List<CartItem>>(cart)
             ?? new List<CartItem>();

            return View(carts);
        }

        // ==========================================
        // ACTION ÁP DỤNG MÃ GIẢM GIÁ (DÙNG AJAX)
        // ==========================================
        [HttpPost]
        public async Task<IActionResult> ApplyVoucher(string code, decimal temporaryTotal)
        {
            if (string.IsNullOrEmpty(code))
                return Json(new { success = false, message = "Vui lòng nhập mã giảm giá!" });

            var voucher = await _context.Vouchers
                .FirstOrDefaultAsync(v => v.Code == code && v.IsActive && v.Quantity > 0
                                       && v.StartDate.Date <= DateTime.Today
                                       && v.EndDate.Date >= DateTime.Today);

            if (voucher == null)
                return Json(new { success = false, message = "Mã không tồn tại hoặc đã hết hạn!" });

            if (voucher.MinOrder.HasValue && temporaryTotal < voucher.MinOrder.Value)
                return Json(new { success = false, message = $"Đơn hàng chưa đạt {voucher.MinOrder.Value:N0}đ!" });

            decimal discountAmount = voucher.IsPercent
                                     ? temporaryTotal * (decimal)(voucher.Discount / 100)
                                     : (decimal)voucher.Discount;

            // LƯU VÀO SESSION
            HttpContext.Session.SetString("AppliedVoucher", code);
            HttpContext.Session.SetString("DiscountAmount", discountAmount.ToString("F0"));

            return Json(new
            {
                success = true,
                message = "Áp dụng thành công!",
                discountAmount = discountAmount,
                newTotal = temporaryTotal - discountAmount
            });
        }
        [HttpPost]
        public IActionResult Checkout(CheckoutModel model)
        {
            var customer = HttpContext.Session.GetObject<Customer>("customer");
            if (customer == null) return RedirectToAction("Login", "Account");

            var cart = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cart)) return RedirectToAction("Index");
            var carts = JsonConvert.DeserializeObject<List<CartItem>>(cart);

            // Cập nhật thông tin khách hàng
            customer.Name = model.CustomerName;
            customer.Phone = model.Phone;
            customer.Address = model.Address;
            _context.Customers.Update(customer);

            // ĐỌC DỮ LIỆU TỪ SESSION
            string appliedVoucher = HttpContext.Session.GetString("AppliedVoucher");
            string discountStr = HttpContext.Session.GetString("DiscountAmount");
            decimal discount = 0;
            decimal.TryParse(discountStr, out discount);

            // TẠO ĐƠN HÀNG
            Order order = new Order()
            {
                Id = Guid.NewGuid(), // Đảm bảo tạo ID mới
                CustomerId = customer.Id,
                CreatedOn = DateTime.Now,
                Status = "Chờ duyệt",
                DiscountCode = appliedVoucher, // Gán giá trị vào đây
                DiscountAmount = discount      // Gán giá trị vào đây
            };

            _context.Orders.Add(order);

            // Lưu chi tiết
            foreach (var item in carts)
            {
                _context.Details.Add(new Details
                {
                    OrderId = order.Id,
                    ProductId = item.Id,
                    Price = item.Price,
                    Amount = item.Quantity
                });
            }

            // Giảm số lượng voucher trong DB
            if (!string.IsNullOrEmpty(appliedVoucher))
            {
                var dbVoucher = _context.Vouchers.FirstOrDefault(v => v.Code == appliedVoucher);
                if (dbVoucher != null) { dbVoucher.Quantity--; }
            }

            _context.SaveChanges();

            // DỌN DẸP SESSION
            HttpContext.Session.Remove("Cart");
            HttpContext.Session.Remove("AppliedVoucher");
            HttpContext.Session.Remove("DiscountAmount");

            return RedirectToAction("Index", "Home");
        }
    }
}
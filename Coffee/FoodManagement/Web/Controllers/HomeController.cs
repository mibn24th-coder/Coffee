using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models.EF; // ??m b?o ?úng namespace ch?a FoodContext
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http; // Thêm ?? dùng Session n?u c?n

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        // 1. Thêm bi?n k?t n?i c? s? d? li?u
        private readonly FoodContext _dbContext;

        // 2. Thêm Constructor ?? kh?i t?o k?t n?i database
        public HomeController(FoodContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 3. S?a hàm Index thành Async ?? t?i d? li?u m??t mà h?n
        public async Task<IActionResult> Index()
        {
            if (_dbContext.Vouchers != null)
            {
                var today = DateTime.Today; // L?y ngày hi?n t?i (00:00:00) b? qua chênh l?ch gi? gi?c

                // L?y t?i ?a 4 Voucher ?ang ho?t ??ng, còn s? l??ng và trong h?n s? d?ng
                var activeVouchers = await _dbContext.Vouchers
                    .Where(v => v.IsActive
                                && v.Quantity > 0
                                && v.StartDate.Date <= today
                                && v.EndDate.Date >= today)
                    .OrderByDescending(v => v.CreatedOn)
                    .Take(4)
                    .ToListAsync();

                // Truy?n d? li?u qua ViewBag sang trang giao di?n
                ViewBag.Vouchers = activeVouchers;
            }

            return View();
        }

        // 4. Hàm x? lý nh?n mã gi?m giá g?i t? trang Gi? hàng/Thanh toán qua Ajax
        [HttpPost]
        public async Task<IActionResult> ApplyVoucher(string code, decimal temporaryTotal)
        {
            if (string.IsNullOrEmpty(code))
            {
                return Json(new { success = false, message = "Vui lòng nh?p mã gi?m giá!" });
            }

            if (_dbContext.Vouchers == null)
            {
                return Json(new { success = false, message = "H? th?ng mã gi?m giá hi?n t?i không kh? d?ng!" });
            }

            var today = DateTime.Today;

            // Tìm voucher h?p l? trong database
            var voucher = await _dbContext.Vouchers
                .FirstOrDefaultAsync(v => v.Code == code
                                       && v.IsActive
                                       && v.Quantity > 0
                                       && v.StartDate.Date <= today
                                       && v.EndDate.Date >= today);

            if (voucher == null)
            {
                return Json(new { success = false, message = "Mã gi?m giá không t?n t?i ho?c ?ã h?t h?n!" });
            }

            // Ki?m tra ?i?u ki?n ??n hàng t?i thi?u (MinOrder)
            if (voucher.MinOrder.HasValue && temporaryTotal < voucher.MinOrder.Value)
            {
                return Json(new
                {
                    success = false,
                    message = $"??n hàng ch?a ??t giá tr? t?i thi?u {voucher.MinOrder.Value:N0}? ?? áp d?ng mã này!"
                });
            }

            // Tính s? ti?n ???c gi?m
            decimal discountAmount = 0;
            if (voucher.IsPercent)
            {
                discountAmount = temporaryTotal * (decimal)(voucher.Discount / 100);
            }
            else
            {
                discountAmount = (decimal)voucher.Discount;
            }

            // L?u thông tin voucher vào Session ?? trang ??t hàng tính toán l?i t?ng ti?n khi l?u DB
            HttpContext.Session.SetString("AppliedVoucher", code);
            HttpContext.Session.SetString("DiscountAmount", discountAmount.ToString());

            return Json(new
            {
                success = true,
                message = "Áp d?ng mã gi?m giá thành công!",
                discountAmount = discountAmount,
                newTotal = temporaryTotal - discountAmount
            });
        }

        [Route("About")]
        public IActionResult About()
        {
            return View();
        }

        [Route("Service")]
        public IActionResult Service()
        {
            return View();
        }

        [Route("Article")]
        public IActionResult Article()
        {
            return View();
        }

        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendContact(Contact model)
        {
            // Tự động điền email nếu khách hàng đã đăng nhập mà bỏ trống ô Email trên Form
            if (string.IsNullOrEmpty(model.Email))
            {
                var sessionEmail = HttpContext.Session.GetString("UserEmail");
                if (!string.IsNullOrEmpty(sessionEmail))
                {
                    model.Email = sessionEmail;
                }
                else if (User.Identity != null && User.Identity.IsAuthenticated)
                {
                    model.Email = User.Identity.Name;
                }
            }

            // Gỡ bỏ kiểm tra validation của Email nếu nó đã được tự động điền ở trên
            ModelState.Remove("Email");

            if (ModelState.IsValid)
            {
                // Tự gán các giá trị hệ thống trước khi lưu
                model.Id = Guid.NewGuid();
                model.CreatedOn = DateTime.Now;
                model.IsReplied = false; // Mặc định là chưa trả lời

                // Lệnh thêm model vào bảng Contacts và lưu lại
                _dbContext.Contacts.Add(model);
                await _dbContext.SaveChangesAsync();

                // Trả về kết quả dạng Json cho AJAX ở giao diện xử lý thông báo
                return Json(new { success = true, message = "Gửi lời nhắn thành công!" });
            }
            return Json(new { success = false, message = "Vui lòng điền đủ thông tin!" });
        }

        [HttpGet]
        [Route("CheckReply")]
        public async Task<IActionResult> CheckReply(string email)
        {
            // 1. Tự động nhận diện Email nếu khách hàng đã đăng nhập trước đó
            var sessionEmail = HttpContext.Session.GetString("UserEmail"); // Lấy từ Session

            if (!string.IsNullOrEmpty(sessionEmail))
            {
                email = sessionEmail;
            }
            else if (User.Identity != null && User.Identity.IsAuthenticated) // Lấy từ Identity (nếu có)
            {
                email = User.Identity.Name;
            }

            // 2. Nếu không đăng nhập VÀ cũng không nhập email tra cứu -> trả về danh sách rỗng
            if (string.IsNullOrEmpty(email))
            {
                return View(new List<Contact>());
            }

            // 3. Truy vấn danh sách tin nhắn theo Email, sắp xếp giảm dần theo ngày gửi
            var history = await _dbContext.Contacts
                .Where(x => x.Email.ToLower() == email.ToLower())
                .OrderByDescending(x => x.CreatedOn)
                .ToListAsync();

            // Dùng ViewBag để giữ lại email khách (hiển thị thông báo hoặc điền vào ô tìm kiếm)
            ViewBag.EmailSearch = email;

            // Trả về View cùng với cục dữ liệu history
            return View(history);
        }
        [Route("Team")]
        public IActionResult Team()
        {
            return View();
        }

        [Route("Testimonial")]
        public IActionResult Testimonial()
        {
            return View();
        }
    }
}

using Core.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Extensions;
using Web.Models.EF;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly FoodContext _dbContext;


        public AccountController(FoodContext dbContext)
        {
            _dbContext = dbContext;
        }



        // =========================
        // HIỂN THỊ TRANG ĐĂNG NHẬP
        // =========================
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        // =========================
        // XỬ LÝ ĐĂNG NHẬP
        // =========================
        [HttpPost]
        public IActionResult Login(string loginName, string password)
        {

            var customer = _dbContext.Customers
                .FirstOrDefault(x =>
                    x.LoginName == loginName &&
                    x.Password == password);



            // Sai tài khoản
            if (customer == null)
            {
                ViewBag.Error = "Sai tên đăng nhập hoặc mật khẩu";

                return View();
            }



            // Lưu khách hàng vào Session
            HttpContext.Session.SetObject("customer", customer);



            // Đăng nhập thành công
            return RedirectToAction("Index", "Home");
        }





        // =========================
        // TRANG ĐĂNG KÝ
        // =========================
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }





        // =========================
        // XỬ LÝ ĐĂNG KÝ
        // =========================
        [HttpPost]
        public IActionResult Register(Customer customer)
        {

            customer.Id = Guid.NewGuid();

            customer.CreatedDate = DateTime.Now;


            _dbContext.Customers.Add(customer);

            _dbContext.SaveChanges();

            return RedirectToAction("Login");
        }





        // =========================
        // THÔNG TIN CÁ NHÂN
        // =========================
        public IActionResult Profile()
        {

            var customer = HttpContext.Session
                .GetObject<Customer>("customer");


            if (customer == null)
            {
                return RedirectToAction("Login");
            }


            return View(customer);
        }





        // =========================
        // ĐĂNG XUẤT
        // =========================
        public IActionResult Logout()
        {

            HttpContext.Session.Remove("customer");


            return RedirectToAction("Index", "Home");
        }

    }
}
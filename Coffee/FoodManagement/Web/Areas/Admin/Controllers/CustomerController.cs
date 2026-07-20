using Core.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models.EF;


namespace Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CustomerController : Controller
    {

        private readonly FoodContext _context;


        public CustomerController(FoodContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {

            var customers = _context.Customers
                .Include(x => x.Orders)
                .ToList();


            return View(customers);

        }


    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models.EF;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly FoodContext _dbContext;
        public ProductController(FoodContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetIsComming()
        {
            var items = from p in _dbContext.Products
                        where p.IsComming == true
                        orderby p.CreatedBy descending
                        select p;
            return Ok(await items.Select(i => new {i.Id, i.Picture, i.Title, i.Intro, i.Price}).ToListAsync());
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var product = await _dbContext.Products
                                          .FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}

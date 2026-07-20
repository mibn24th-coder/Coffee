using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models.EF;
using Core.Database.Models;

namespace Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly FoodContext _context;

        public NewsController(FoodContext context)
        {
            _context = context;
        }

        // Danh sách tin tức
        public async Task<IActionResult> Index()
        {
            var news = await _context.Articles
                .OrderByDescending(x => x.CreatedOn)
                .ToListAsync();

            return View(news);
        }

        // Chi tiết tin tức
        public async Task<IActionResult> Detail(Guid id)
        {
            var item = await _context.Articles
                .FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
    }
}
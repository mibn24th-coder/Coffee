using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Models;
using Web.Models.EF;
using System.Linq.Dynamic.Core;
using Core.Database.Models;
using Microsoft.EntityFrameworkCore;
using Order = Core.Database.Models.Order;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly FoodContext _dbContext;
        public OrderController(FoodContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(Guid id)
        {
            var order = _dbContext.Orders
                .Include(x => x.Customer)
                .FirstOrDefault(x => x.Id == id);

            if (order == null)
                return NotFound();

            ViewBag.Customer = order.Customer;

            return View(order);
        }
        [HttpPost]
        public async Task<IActionResult> GetDetailsList(jDatatable model, Guid orderId)
        {
            var items = _dbContext.Details
             .Include(x => x.Product)
             .Where(x => x.OrderId == orderId)
             .AsQueryable();
            int recordsTotal = 0;
            recordsTotal = items.Count();
            var data = await items.Select(i => new
            {
                i.Id,
                productName = i.Product != null ? i.Product.Title : "",
                i.Amount,
                i.Price,
                total = (i.Amount ?? 0) * (i.Price ?? 0m)
            }).Skip(model.start).Take(model.length).ToListAsync();
            var jsonData = new { draw = model.draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
            return Ok(jsonData);

        }
        [HttpPost]
        public async Task<IActionResult> GetList(jDatatable model)
        {
            IQueryable<Order> items = _dbContext.Orders.Include(x => x.Customer).AsQueryable();
            int recordsTotal = 0;
            if (!string.IsNullOrEmpty(model.columns[model.order[0].column].name) && !string.IsNullOrEmpty(model.order[0].dir))
            {
                items = items.OrderBy(model.columns[model.order[0].column].name + ' ' + model.order[0].dir);
            }
            if (!string.IsNullOrEmpty(model.search.value))
            {
                items = items.Where(i => i.Customer.Name.Contains(model.search.value));
            }
            recordsTotal = items.Count();
            var data = await items.Select(i => new
            {
                i.Id,
                customerName = i.Customer.Name,
                i.CreatedOn,
                i.UpdatedOn,
                i.Status
            }).Skip(model.start).Take(model.length).ToListAsync();
            var jsonData = new { draw = model.draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
            return Ok(jsonData);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _dbContext.Orders.FindAsync(id);
            if(item.UpdatedOn == null)
                return Ok(false);  
            var details = await _dbContext.Details.Where(i => i.OrderId == id).ToListAsync();
            _dbContext.Details.RemoveRange(details);
            _dbContext.Entry(item).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return Ok(true);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var order = await _dbContext.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            return View(order);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(Guid id, string status)
        {
            var order = await _dbContext.Orders.FindAsync(id);

            if (order == null)
                return Ok(false);

            order.Status = status;
            order.UpdatedOn = DateTime.Now;

            await _dbContext.SaveChangesAsync();

            return Ok(true);
        }
    }
}

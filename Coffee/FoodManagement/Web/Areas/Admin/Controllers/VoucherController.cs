using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Models;
using Web.Models.EF;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Core.Database.Models;
using Web.Areas.Admin.Extensions;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VoucherController : Controller
    {
        private readonly FoodContext _dbContext;

        public VoucherController(FoodContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        // API trả về danh sách Voucher dạng JSON cho DataTable
        [HttpPost]
        public async Task<IActionResult> GetList(jDatatable model)
        {
            var items = (from i in _dbContext.Vouchers select i);
            int recordsTotal = 0;

            // Kiểm tra an toàn trước khi sắp xếp theo cột
            if (model.order != null && model.order.Count > 0 && model.columns != null &&
                !string.IsNullOrEmpty(model.columns[model.order[0].column].name) && !string.IsNullOrEmpty(model.order[0].dir))
            {
                items = items.OrderBy(model.columns[model.order[0].column].name + ' ' + model.order[0].dir);
            }

            // Tìm kiếm theo Mã Voucher (Code)
            if (model.search != null && !string.IsNullOrEmpty(model.search.value))
            {
                items = items.Where(i => i.Code.Contains(model.search.value));
            }

            recordsTotal = await items.CountAsync();

            var data = await items.Select(i => new
            {
                i.Id,
                i.Code,
                i.Discount,
                i.IsPercent,
                i.MinOrder,
                i.StartDate,
                i.EndDate,
                i.IsActive
            }).Skip(model.start).Take(model.length).ToListAsync();

            var jsonData = new { draw = model.draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
            return Ok(jsonData);
        }

        // API lấy thông tin chi tiết của 1 voucher để đưa lên form sửa
        [HttpGet]
        public async Task<IActionResult> GetItem(Guid id)
        {
            if (_dbContext.Vouchers == null)
                return NotFound();
            var item = await _dbContext.Vouchers.FindAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        // API lưu dữ liệu (Thêm mới hoặc Cập nhật)
        [HttpPost]
        public async Task<IActionResult> Save(VoucherViewModel model)
        {
            if (_dbContext.Vouchers == null) return BadRequest("Cơ sở dữ liệu trống.");

            Voucher item;
            var loggedMember = HttpContext.Session.GetObject<Member>("member");
            Guid? memberId = loggedMember != null ? loggedMember.Id : null;

            if (model.Id == null || model.Id == Guid.Empty)
            {
                // Thêm mới
                item = new Voucher();
                item.Id = Guid.NewGuid();
                item.CreatedBy = memberId;
                item.CreatedOn = DateTime.Now;
                await _dbContext.Vouchers.AddAsync(item);
            }
            else
            {
                // Cập nhật
                item = await _dbContext.Vouchers.FindAsync(model.Id);
                if (item == null) return NotFound();
                item.ModifiedOn = DateTime.Now;
                item.ModifiedBy = memberId;
            }

            // Gán dữ liệu từ model gửi lên vào entity
            item.Code = model.Code;
            item.Discount = model.Discount;
            item.IsPercent = model.IsPercent;
            item.MinOrder = model.MinOrder;
            item.StartDate = model.StartDate;
            item.EndDate = model.EndDate;
            item.Quantity = model.Quantity;
            item.IsActive = model.IsActive;

            await _dbContext.SaveChangesAsync();
            return Ok(item);
        }

        // API xóa voucher
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var item = await _dbContext.Vouchers.FindAsync(id);
                if (item == null) return Ok(false);

                _dbContext.Entry(item).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
                return Ok(true);
            }
            catch
            {
                return Ok(false);
            }
        }
    }
}
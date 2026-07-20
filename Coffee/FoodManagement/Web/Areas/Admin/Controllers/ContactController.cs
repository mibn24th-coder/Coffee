using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models.EF;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")] // Định tuyến vào vùng Admin
    public class ContactController : Controller
    {
        private readonly FoodContext _dbContext;

        public ContactController(FoodContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Trang danh sách hiển thị toàn bộ tin nhắn liên hệ
        public async Task<IActionResult> Index()
        {
            var list = await _dbContext.Contacts
                .OrderByDescending(x => x.CreatedOn)
                .ToListAsync();

            return View(list);
        }

        // 2. Hàm xử lý phản hồi tin nhắn nhận qua AJAX
        [HttpPost]
        public async Task<IActionResult> Reply(Guid id, string replyMessage)
        {
            if (string.IsNullOrEmpty(replyMessage))
            {
                return Json(new { success = false, message = "Vui lòng nhập nội dung trả lời!" });
            }

            var contact = await _dbContext.Contacts.FindAsync(id);
            if (contact != null)
            {
                contact.ReplyMessage = replyMessage;
                contact.ReplyOn = DateTime.Now;
                contact.IsReplied = true; // Đánh dấu đã trả lời thành công

                await _dbContext.SaveChangesAsync();
                return Json(new { success = true });
            }

            return Json(new { success = false, message = "Không tìm thấy dữ liệu liên hệ!" });
        }
    }
}
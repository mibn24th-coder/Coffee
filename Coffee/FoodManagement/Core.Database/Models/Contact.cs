using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.EF
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tiêu đề")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nội dung")]
        public string? Message { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        // --- Phần dành cho Admin phản hồi ---
        public string? ReplyMessage { get; set; } // Nội dung admin trả lời
        public DateTime? ReplyOn { get; set; }     // Ngày trả lời
        public bool IsReplied { get; set; } = false; // Đã trả lời chưa
    }
}
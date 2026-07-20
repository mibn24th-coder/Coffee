using System;

namespace Web.Areas.Admin.Models
{
    public class VoucherViewModel
    {
        public Guid? Id { get; set; }
        public string Code { get; set; } = "";
        public decimal Discount { get; set; }
        public bool IsPercent { get; set; }
        public decimal? MinOrder { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
    }
}
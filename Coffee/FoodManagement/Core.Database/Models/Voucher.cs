using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Database.Interfaces;

namespace Core.Database.Models
{
    [Table("Vouchers")]
    public class Voucher : IAuditable
    {
        [Key]
        public Guid Id { get; set; }

        public string Code { get; set; } = "";

        public decimal Discount { get; set; }

        public bool IsPercent { get; set; }

        public decimal? MinOrder { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Quantity { get; set; }

        public bool IsActive { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
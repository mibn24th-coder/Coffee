namespace Core.Database.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = "";

        public string? Picture { get; set; }

        public decimal? Price { get; set; }

        public int Quantity { get; set; }
    }
}
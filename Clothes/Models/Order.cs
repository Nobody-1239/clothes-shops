namespace Clothes.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public ICollection<OrderItem> OrderItem { get; set; }

        public decimal totalprice => OrderItem?.Sum(s => s.TotalPrice) ?? 0;

    }
}

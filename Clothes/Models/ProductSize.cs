namespace Clothes.Models
{
    public class ProductSize
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public product Product { get; set; }
        public string Sizes { get; set; } 
        public int Stock { get; set; }
    }
}


namespace Clothes.Models
{
    public class product
    {
        public enum GenderType
        {
            women = 1,
            men = 2,
            childer = 3,
            accessory = 4
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string Sizes { get; set; }

        public Category category { get; set; }
        public GenderType gender { get; set; }
        public List<ProductSize> Size { get; set; }
    }
}

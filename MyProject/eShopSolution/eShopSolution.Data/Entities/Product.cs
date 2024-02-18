namespace eShopSolution.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Stock { get; set; }
        public int ViewCount { get; set; }
        public DateTime DateCreated { get; set; }

        public ICollection<ProductInCategory> ProductInCategories { get; set; } = null!;
        public ICollection<OrderDetail> OrderDetails { get; set; } = null!;
        public ICollection<ProductTranslation> ProductTranslations { get; set; } = null!;
        public ICollection<Cart> Carts { get; set; } = null!;
    } 
}

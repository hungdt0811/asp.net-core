namespace eShopSolution.ViewModels.Catalog.Product.Manage
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }
        public string Name { set; get; } = null!;
        public string Description { set; get; } = null!;
        public string Details { set; get; } = null!;
        public string SeoDescription { set; get; } = null!;
        public string SeoTitle { set; get; } = null!;
        public string SeoAlias { get; set; } = null!;
        public string LanguageId { set; get; } = null!;
        public IFormFile ThumbnailImage { set; get; }
    }
}

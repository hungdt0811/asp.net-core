using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities.Exceptions;
using eShopSolution.ViewModels.Catalog.Product;
using eShopSolution.ViewModels.Catalog.Product.Manage;
using eShopSolution.ViewModels.Common;
using Microsoft.EntityFrameworkCore;

namespace eShopSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopDbContext _context;
        public ManageProductService(EShopDbContext context)
        {
            _context = context;
        }

        // Phương thức xử lý addViewCount
        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId); // Lấy ra product
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        // Phương thức xử lý thêm product
        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>() 
                { 
                    new ProductTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId = request.LanguageId,
                    }
                }
            };
            _context.Add(product);
            return await _context.SaveChangesAsync();
        }

        // Phương thức xử lý xóa product
        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId); // Tìm kiếm product theo giá trị của khóa chính
            if (product == null) throw new EShopException($"Cannot find a product: {productId}");

            _context.Products.Remove(product);        // Xóa product khỏi database
            return await _context.SaveChangesAsync(); // Trả về số bản ghi được delete
        }

        // Phương thức xử lý tìm kiếm và phân trang
        public async Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            // Select: Lấy ra tập hợp
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p , pt, pic };

            // Filter: Tìm kiếm keyword theo tên sản phẩm
            if(!string.IsNullOrEmpty(request.Keyword)) // Kiểm tra xem chuỗi keyword có null hay không
            {
                query = query.Where(x => x.pt.Name.Contains(request.Keyword)); // Tìm kiếm theo tên sản phẩm
            }
            // Tìm kiếm keyword theo tên sản phẩm và tên category
            if (request.CategoryIds.Count > 0) // Kiểm tra xem trong request.CategoryIds có chứa ID danh mục nào không
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
            }

            // Paging (Phân trang)
            int totalRecord = await query.CountAsync(); // Lấy ra tổng số bản ghi mà query trả về
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {   
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt .SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                }).ToListAsync();

            // Select and projection
            var pageResult = new PageResult<ProductViewModel>()
            {
                TotalRecord = totalRecord,
                Items = data,
            };
            return pageResult;
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id); // Lấy ra product có Id được truyền trong request
            var productTranlations = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id && x.LanguageId == request.LanguageId); // Lấy ra productTranslation có Id được truyền trong request và chỉ update cho 1 ngôn ngữ
            if (product == null || productTranlations == null) throw new EShopException($"Can't find a product with ID: {request.Id}");

            productTranlations.Name = request.Name;
            productTranlations.SeoTitle = request.SeoTitle;
            productTranlations.SeoDescription = request.SeoDescription;
            productTranlations.SeoAlias = request.SeoAlias;
            productTranlations.Name = request.Name;
            productTranlations.Description = request.Description;
            productTranlations.Details = request.Details;

            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int ProductId, decimal NewPrice)
        {
            var product = await _context.Products.FindAsync(ProductId); // Lấy ra product có Id tương ứng
            if (product == null) throw new EShopException($"Can't find a product with ID: {ProductId}");

            product.Price = NewPrice;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int ProductId, int addQuantity)
        {
            var product = await _context.Products.FindAsync(ProductId); // Lấy ra product có Id tương ứng
            if (product == null) throw new EShopException($"Can't find a product with ID: {ProductId}");

            product.Stock += addQuantity;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}

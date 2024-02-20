using eShopSolution.ViewModels.Catalog.Product;
using eShopSolution.ViewModels.Catalog.Product.Public;
using eShopSolution.ViewModels.Common;

namespace eShopSolution.Application.Catalog.Products
{
    // interface này chuyên chỉ chứa phương thức dành cho phần bên ngoài (client)
    public interface IPublicProductService
    {
        Task<PageResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request);

    }
}

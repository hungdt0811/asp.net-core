using eShopSolution.ViewModels.Catalog.Product;
using eShopSolution.ViewModels.Catalog.Product.Manage;
using eShopSolution.ViewModels.Common;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);   // Thêm
        Task<int> Update(ProductUpdateRequest request);   // Sửa
        Task<int> Delete(int ProductId);                  // Xóa
        Task<bool> UpdatePrice(int productId, decimal newPrice); // Cập nhật giá
        Task<bool> UpdateStock(int productId, int addQuantity); // Cập nhật số lượng
        Task AddViewCount(int ProductId);
        //Task<List<ProductViewModel>> GetAll(); // Lấy tất cả dữ liệu
        Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request); // Tìm kiếm

    }
}

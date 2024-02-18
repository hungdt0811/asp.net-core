using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Catalog.Products.Dtos.Public;
using eShopSolution.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    // interface này chuyên chỉ chứa phương thức dành cho phần bên ngoài (client)
    public interface IPublicProductService
    {
        PageResult<ProductViewModel> GetAllByCategoryId(GetProductPagingRequest request);

    }
}

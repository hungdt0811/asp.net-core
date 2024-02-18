﻿using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Catalog.Products.Dtos.Manage;
using eShopSolution.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);   // Thêm
        Task<int> Update(ProductUpdateRequest request);   // Sửa
        Task<int> Delete(int ProductId);                  // Xóa
        Task<bool> UpdatePrice(int ProductId, decimal NewPrice); // Cập nhật giá
        Task<bool> UpdateStock(int ProductId, decimal addQuantity); // Cập nhật số lượng
        Task AddViewCount(int ProductId);
        Task<List<ProductViewModel>> GetAll();
        Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);

    }
}
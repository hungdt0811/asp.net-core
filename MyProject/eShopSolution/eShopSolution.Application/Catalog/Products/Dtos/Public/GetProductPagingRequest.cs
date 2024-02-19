using eShopSolution.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products.Dtos.Public
{
    public class GetProductPagingRequest : PagingRequsetBase
    {
        public int? CategoryId { get; set; }
    }
}

using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ViewModels.Catalog.Product.Manage
{
    public class GetProductPagingRequest : PagingRequsetBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}

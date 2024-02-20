using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ViewModels.Common
{
    public class PagingRequsetBase
    {
        public int PageIndex { get; set; } // Vị trí lấy trang số bao nhiêu
        public int PageSize { get; set; }   // kích cỡ của trang
    }
}

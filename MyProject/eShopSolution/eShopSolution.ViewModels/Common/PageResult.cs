using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ViewModels.Common
{
    // common DTO
    public class PageResult<T>
    {
        public List<T> Items { get; set; } = null!;
        public int TotalRecord { get; set; }

    }
}

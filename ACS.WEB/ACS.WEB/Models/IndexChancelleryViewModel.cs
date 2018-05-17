using ACS.WEB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACS.WEB.ViewModel
{
    public class PageInfo
    {
        public int PageNumber { get; set; } // номер текущей страницы
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages  // всего страниц
        {
            get { var result = (int)Math.Ceiling((decimal)TotalItems / PageSize); return result; }
        }
    }
    public class IndexChancelleryViewModel
    {
        public IEnumerable<ChancelleryViewModel> Chancelleries { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
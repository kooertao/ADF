using System.Collections.Generic;

namespace ADF.Core.Model
{
    public class PageModel<T>
    {
        public int Page { get; set; } = 1;
        public int PageCount { get; set; } = 6;
        public int DataCount { get; set; } = 0;
        public int PageSize { get; set; } 
        public List<T> Data { get; set; }
    }
}

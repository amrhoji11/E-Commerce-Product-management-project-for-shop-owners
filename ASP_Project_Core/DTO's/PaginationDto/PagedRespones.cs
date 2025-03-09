using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.DTO_s
{
    public class PagedRespones<ItemDto>
    {
        public int total_items { get; set; }
        public int page_index { get; set; }
        public int page_size { get; set; }
        public IEnumerable<ItemDto> items { get; set; }

    }
}

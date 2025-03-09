using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.DTO_s
{
    public class InvoiceItemDto
    {

        public string item_name { get; set; }
        public double quantity { get; set; }
        public string unit_name { get; set; }
        public double price_per_unit { get; set; }
        public  double total_price { get; set; }
    }
}

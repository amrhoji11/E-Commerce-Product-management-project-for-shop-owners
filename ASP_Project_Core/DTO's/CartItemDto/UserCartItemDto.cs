using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.DTO_s
{
    public class UserCartItemDto
    {
        public string name { get; set; }
        public double price { get; set; }
        public string itemUnits { get; set; }
        public double Quantity { get; set; }
    }
}

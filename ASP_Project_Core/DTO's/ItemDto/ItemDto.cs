using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.DTO_s
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public List<string> ItemUnits { get; set; } //unit الواحد قد يكزن له اكثر من  item  الواحد فال item لل units  تخزن ال
        
        public List<string> Stores { get; set; }
    
    }



}

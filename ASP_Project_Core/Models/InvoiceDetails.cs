using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.Models
{
    public class InvoiceDetails //invoice and items نتيجة العلاقة نتعدد لمتعدد بين ال 
    {
        [ForeignKey(nameof(Invoice))]
        public int Invoice_Id { get; set; }

        [ForeignKey(nameof(Items))]
        public int Item_Id { get; set; }
        public int Price { get; set; }
        public int Unit_Id { get; set; }
        public double  Quantity { get; set; }
        public int  Factor { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Invoice Invoice { get; set; }
        public Items Items { get; set; }


    }
}

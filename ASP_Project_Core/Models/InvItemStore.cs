using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.Models
{
    public class InvItemStore // items و Storesهاذ الكلاس نتيجة العلاقة متعدد لمتعدد بين ال 
    {
        [ForeignKey(nameof(Stores))]
        public int Store_Id { get; set; }

        [ForeignKey(nameof(Items))]
        public int Item_Id { get; set; }

        public double Balance { get; set; } // item الكمية تاعت كل 

        public double ReservedQuantity { get; set; } // الكمية التي تم حجزها عند عمل الفاتورة

        public int Factor { get; set; } //    ( (unite)مثل خمس كزايز عصير في الكرتونة ) uniteهو الجزء من ال

        public DateTime LastUpdated { get; set; } // اخر وقت تم التعديل على منتج معين موجود في ستور معين
        public Items Items { get; set; }
        public Stores Stores { get; set; }

    }
}

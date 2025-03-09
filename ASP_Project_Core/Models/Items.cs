using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.Models
{
    public class Items
    {
        public int Id { get; set; }
            public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        [ForeignKey(nameof(MainGroup))]
        public int MG_Id { get; set; }

        [ForeignKey(nameof(subGroup))]
        public int Sub_Id { get; set; }

        [ForeignKey(nameof(subGroup2))]
        public int Sub2_Id { get; set; }

        public MainGroup MainGroup { get; set; }
        public SubGroup subGroup { get; set; }
        public SubGroup2 subGroup2 { get; set; }

        public ICollection<InvItemStore> InvItemStore { get; set; }

        public ICollection<ItemsUnits> ItemsUnits { get; set; } = new HashSet<ItemsUnits>();
        public ICollection<InvoiceDetails> invoiceDetails { get; set; } = new HashSet<InvoiceDetails>();

        // main category lev1==> مثل البان
        // sub category lev2====> مثل:البان معلبة
        // sub2 category lev3===> مثل: لبن كثير الدسم, لبن خالي الدسم ,...الخ



    }
}

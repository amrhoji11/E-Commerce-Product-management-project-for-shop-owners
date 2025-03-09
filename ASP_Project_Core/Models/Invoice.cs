using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Users))]
        public int Cus_Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
        public double NetPrice { get; set; }
        public int Transaction_Types { get; set; } // هل الفاتورة تمت ام مرتجعة يعني حصل غلط فيها
        public int Payment_Type { get; set; }
  
        public bool IsPosted { get; set; }// معناها ان الفاتورة انعملت
        public bool IsReviewed { get; set; } //معناها ان الفاتورة ببتجهز يعني تم خصم حجز المنتجات من الستور وهكذا
        public bool IsClosed { get; set; }// ان الفاتورة اتسلمت

        public Users Users { get; set; }

        public ICollection<InvoiceDetails> invoiceDetails { get; set; } = new HashSet<InvoiceDetails>();





    }


}

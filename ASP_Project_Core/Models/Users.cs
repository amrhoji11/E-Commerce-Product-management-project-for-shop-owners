using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.Models
{
    public  class Users :IdentityUser<int> // string  و ليس int  هو idهنا معناها انو خلي نوع ال  <int> ال 
    { 
        [ForeignKey(nameof(Goverments))]
        public int Gov_Id { get; set; }

        [ForeignKey(nameof(Cities))]
        public int City_Id { get; set; }

        [ForeignKey(nameof(Zones))]
        public int Zone_Id { get; set; }

        [ForeignKey(nameof(Classifications))]
        public int Class_Id { get; set; }

        public Goverments Goverments { get; set; } 
        public Cities Cities { get; set; }
        public Zones Zones { get; set; }

        public Classifications Classifications { get; set; }

        public ICollection<Invoice> Invoices { get; set; } = new HashSet<Invoice>();
        public ICollection<CustomersStores> CustomersStores { get; set; } = new HashSet<CustomersStores>();



    }
}

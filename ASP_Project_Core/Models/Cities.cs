using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.Models
{
    public class Cities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(Goverments))]
        public int Gov_Id { get; set; }

        public Goverments Goverments { get; set; }

        public ICollection<Users> Users { get; set; }=new HashSet<Users>();
        public ICollection<Zones> Zones { get; set; } = new HashSet<Zones>();
        public ICollection<Stores> Stores { get; set; } = new HashSet<Stores>();

    }
}

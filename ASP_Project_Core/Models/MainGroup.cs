using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.Models
{
    public  class MainGroup
    { //main Category
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Items> Items { get; set; }=new HashSet<Items>();
        public ICollection<SubGroup> subGroups { get; set; } = new HashSet<SubGroup>();
        public ICollection<SubGroup2> SubGroup2 { get; set; } = new HashSet<SubGroup2>();



    }
}

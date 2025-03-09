using ASP_Project_Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.DTO_s
{
    public class AddItems
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        
        public int MG_Id { get; set; }

      
        public int Sub_Id { get; set; }

       
        public int Sub2_Id { get; set; }
    }
}

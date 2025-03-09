using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.DTO_s
{
    public class UpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }


        public int MG_Id { get; set; }


        public int Sub_Id { get; set; }


        public int Sub2_Id { get; set; }
    }
}

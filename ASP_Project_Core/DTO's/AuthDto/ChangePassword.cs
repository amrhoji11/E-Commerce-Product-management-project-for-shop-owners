using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.DTO_s.AuthDto
{
    public class ChangePassword  // طبعا هذه الطريقة ليست ممتازة ولكنها تمشاية حال
    {
        [DataType(DataType.EmailAddress)]
        public string Name { get; set; }
        
        public string oldPassword { get; set; }
        public string newPassword { get; set; }

    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.DTO_s.AuthDto
{
    public class RoleDto
    {
        [Required]
        public string RoleName { get; set; }
    }
}

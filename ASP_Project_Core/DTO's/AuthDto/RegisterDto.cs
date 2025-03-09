using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.DTO_s
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int Gov_Id { get; set; }
        [Required]
        public int City_Id { get; set; }
        [Required]
        public int Zone_Id { get; set; }
        [Required]
        public int Cus_ClassId { get; set; }
    }
}

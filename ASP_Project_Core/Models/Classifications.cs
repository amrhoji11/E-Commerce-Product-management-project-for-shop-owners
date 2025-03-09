using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.Models
{
    public class Classifications // يعني يمكن يكون ال يوسر منزل او سوبرماركت او الخ فيمكن انزل عروض للمنزل او للسوبرماركت او للمطاعم User هاذ كلاسفكيشن لل
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Users> Users { get; set; } = new HashSet<Users>();

    }
}

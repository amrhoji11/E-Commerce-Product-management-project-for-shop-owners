using ASP_Project_Core.DTO_s.AuthDto;
using ASP_Project_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.Interfaces
{
    public interface IAuthRepository
    {
        Task<string> RegisterAsync(Users user,string password);
        Task<string> LoginAsync(string username,string password);
        Task<string> ChangePssswordAsync(ChangePassword dto);
        public Task<string> CreatRole(RoleDto role);
        public Task<string> EditRoleForUser(AssignRole role);
    }
}

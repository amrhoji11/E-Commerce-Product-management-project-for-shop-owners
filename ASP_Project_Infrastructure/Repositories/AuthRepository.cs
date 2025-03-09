using ASP_Project_Core.DTO_s.AuthDto;
using ASP_Project_Core.Interfaces;
using ASP_Project_Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ASP_Project_Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole<int>> roleManager;

        public AuthRepository(UserManager<Users>userManager, SignInManager<Users> signInManager,IConfiguration configuration , RoleManager<IdentityRole<int>> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;// appsetting لكي نصل الى ال 
            this.roleManager = roleManager;
        }

        public async Task<string> RegisterAsync(Users user, string password)
        {
            
            var result = await userManager.CreateAsync(user,password);
            if (result.Succeeded)
            {
               var role= await roleManager.FindByNameAsync("User");
                if (role != null)
                {
                    await userManager.AddToRoleAsync(user,role.Name);
                }
                
                
                return "User Registered Successfully";
            }
            var errorMassage = result.Errors.Select(error => error.Description).ToList();
            return string.Join(", ",errorMassage);
            
        }

        public async Task<string> ChangePssswordAsync(ChangePassword dto)
        {
            var user = await userManager.FindByNameAsync(dto.Name);
            if (user == null) 
            {
                return "user not found";
            }
            var prePassword = await userManager.CheckPasswordAsync(user,dto.oldPassword); //يساوي الباسوورد الحالي oldPassword بتشوف هل ال
            if (!prePassword)
            {

                return "the oldPassword is wrong!";

            }
            var result= await userManager.ChangePasswordAsync(user, dto.oldPassword, dto.newPassword);
            if (!result.Succeeded)
            {
                return "user not found";
            }
            return "the Change Password is Succeeded";
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var user = await userManager.FindByNameAsync(username);//للتاكد من هل اليوزر موجود
            if (user == null)
            {
                return null;

            }

            var result = await signInManager.PasswordSignInAsync(user, password, false, false);// للتاكد من الباسوورد
            if (!result.Succeeded)
            {
                return null ;

            }

            return GenerateToken(user); // راح يرجع توكين
        }

        private string GetUserRole(Users user)
        {
            
            // احصل على أدوار المستخدم
            var roles = userManager.GetRolesAsync(user).Result;

            // إذا كان هناك أدوار، اختر أول دور أو أضف شروطك الخاصة
            return roles.FirstOrDefault(); // إذا لم يكن هناك دور، ارجع "User"
        }
        private  string GenerateToken(Users user)
        {

            var role = GetUserRole(user);

            var claims = new[]    //username و userid هون بوخذ ال
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),

                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Role, role)


            };

           


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]));// appsetting المحطوط في ال key  تشفير ال
            var cred = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["JWT:Issure"],
                configuration["JWT:Audience"],
                claims,
                signingCredentials: cred,
                expires: DateTime.Now.AddMinutes(30)
                );


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> CreatRole(RoleDto role)
        {
            if (await roleManager.RoleExistsAsync(role.RoleName))
            {
                return $"the role : {role.RoleName} already exists";

            }
            IdentityRole<int> r = new IdentityRole<int>
            {
                Name = role.RoleName
            };

            var result = await roleManager.CreateAsync(r);
            if (result.Succeeded)
            {
                return $"the role : {role.RoleName} is Created";

            }
            return $"the role is not creat";
           
        }

        public async Task<string> EditRoleForUser(AssignRole role)
        {
            var user = await userManager.FindByIdAsync(role.UserId);
            if (user == null )
            {
                return "user not found";
            }
            var Role = await roleManager.FindByNameAsync(role.RoleName);
            if (Role == null)
            {
                return "role is not exists";
            }
            var CurrentRole = await userManager.GetRolesAsync(user);
            var result = await userManager.RemoveFromRolesAsync(user,CurrentRole);
            await userManager.AddToRoleAsync(user,role.RoleName);

            return "The Edit Role for User is Successfully";


        }
    }
}

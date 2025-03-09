using ASP_Project_Core.DTO_s;
using ASP_Project_Core.DTO_s.AuthDto;
using ASP_Project_Core.Interfaces;
using ASP_Project_Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        /* private readonly IAuthRepository authRepository;*/

        public AuthController(/*IAuthRepository authRepository*/ IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            /*this.authRepository = authRepository;*/
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var user = new Users
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Gov_Id = dto.Gov_Id,
                City_Id = dto.City_Id,
                Zone_Id = dto.Zone_Id,
                Class_Id=dto.Cus_ClassId

            };

            var result = await unitOfWork.AuthRepository.RegisterAsync(user, dto.Password);
            return Ok(result);

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var token = await unitOfWork.AuthRepository.LoginAsync(dto.uername, dto.password);
                if (token == null)
                {
                    return Unauthorized(new { Message = "Invalid username or password" });

                }
                return Ok(token);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error during login {ex.Message}");
                return StatusCode(500,new {Message="an expected error"});
            
            }
           

        }
        [Authorize(Roles ="Admin")]
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(RoleDto role)
        {
            
            if (role == null)
            {
                return NotFound("the role is not found");

            }

            var result = await unitOfWork.AuthRepository.CreatRole(role);
            if (result == "the role is not creat")
            {
                return NotFound("the role is not found");
            }

            if (result == $"the role : {role.RoleName} already exists")
            {
                Ok(result);
            }
            return Ok(result);

        }
        [Authorize(Roles = "Admin")]
        [HttpPost("EditRoleForUser")]
        public async Task<IActionResult> EditRoleForUser(AssignRole role)
        {
            var result = await unitOfWork.AuthRepository.EditRoleForUser(role);
            if (result != "The Edit Role for User is Successfully")
            {
                return NotFound("the user or role is not found");
            }

            return Ok(result);

        }

        [HttpPost("ChangePassword")]

        public async Task<IActionResult> ChangePassword(ChangePassword dto)
        {
            if (! ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
           

            var result = await unitOfWork.AuthRepository.ChangePssswordAsync(dto);
            if (result == "the Change Password is Succeeded")
            {
                return Ok(result);
            }
            return BadRequest(result);

        }











    }
}

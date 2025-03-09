using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ASP_Project_API.HelperFunctions
{
    public class ExtractClaims //     من التوكين Login  هاذ لاستخراج معلومات ال 
    {
        public static int? ExtractUserId(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var JwtToken = tokenHandler.ReadJwtToken(token);

                var userIdClaims = JwtToken.Claims.FirstOrDefault(t => t.Type == ClaimTypes.NameIdentifier);

                if (userIdClaims != null && int.TryParse(userIdClaims.Value, out int userId))
                {
                    return userId;

                }
                return null;

            }
            catch (Exception)
            {

                return null;
            }


        }

        public static string ExtractRole(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);  // قراءة التوكين

                // استخراج الدور (Role) من الادعاءات
                var roleClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

                // إرجاع الدور إذا كان موجودًا
                return roleClaim?.Value;
            }
            catch (Exception)
            {
                return null; // في حالة وجود خطأ أو عدم وجود الدور
            }



        }
    }
}


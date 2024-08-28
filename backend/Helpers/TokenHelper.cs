using backend.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend.Helpers
{
    public class TokenHelper
    {
        private static TokenHelper instance;
        public static TokenHelper Instance
        {
            get { if (instance == null) instance = new TokenHelper(); return TokenHelper.instance; }
            // Đảm bảo rằng chỉ có thể gán giá trị từ bên trong lớp TokenHelper
            private set { TokenHelper.instance = value; }
        }

        // Phương thức tạo token JWT dựa trên email, role và cấu hình
        public string CreateToken(string email, string role, IConfiguration _config)
        {   

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };

            // Tạo khóa bí mật từ giá trị token trong cấu hình ứng dụng
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _config.GetSection("AppSettings:Token").Value!));
            // Tạo SigningCredentials sử dụng khóa và thuật toán ký HmacSha512
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // Tạo JWT Token với các thông tin như claims, thời điểm hết hạn và signingCredential
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            // Chuyển đổi JWT Token thành chuỗi token JWT
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return "bearer " + jwt;
        }
    }
}

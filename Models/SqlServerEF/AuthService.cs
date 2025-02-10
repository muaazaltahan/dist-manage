using dist_manage.DB;
using dist_manage.Models.Commands;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace dist_manage.Models.SqlServerEF
{
    public class AuthService
    {
        private readonly DBContext context;
        private readonly int iteration = 3;
        private readonly string _pepper;
        private readonly string _jwt;
        private readonly IConfiguration configuration;
        public AuthService(DBContext context, IConfiguration config)
        {
            this.context = context;
            configuration = config;
            _pepper = configuration["Secrets:pepper"];
            _jwt = configuration["Secrets:jwt"];
        }

        public async Task<LoginResCmd> Login(LoginReqCmd data)
        {
            var user = context.UsersDB.FirstOrDefault(x => x.Name == data.Username);
            string passHash = ComputeHash(data.Password, _pepper, iteration);
            if (passHash != user.Password) throw new Exception("Wrong Email Or Password!");
            var AccessToken = GenerateToken(user);
            
            return AuthHelpers.GetLoginRes(user, AccessToken);
        }
        private string ComputeHash(string password, string pepper, int iteration)
        {
            if (iteration <= 0) return password;

            using var sha256 = SHA256.Create();
            var passwordSaltPepper = $"{password}{pepper}";
            var byteValue = Encoding.UTF8.GetBytes(passwordSaltPepper);
            var byteHash = sha256.ComputeHash(byteValue);
            var hash = Convert.ToBase64String(byteHash);
            return ComputeHash(hash, pepper, iteration - 1);
        }
        private string GenerateToken(UsersDB data)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, data.Name),
                new Claim("Id", data.Id.ToString()),
                new Claim(ClaimTypes.Role, data.Role.ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(50),
                signingCredentials: creds,
                audience: "",
                issuer: ""
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}

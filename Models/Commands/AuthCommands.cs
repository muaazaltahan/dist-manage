using dist_manage.DB;

namespace dist_manage.Models.Commands
{
    public class LoginReqCmd
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
    public class RegisterUserReqCmd
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public int Role { get; set; }
    }
    public class LoginResCmd : UsersDB
    {
        public string AccessToken { get; set; }
    }
    public static class AuthHelpers
    {
        public static LoginResCmd GetLoginRes(UsersDB user, string token)
        {
            return new LoginResCmd
            {
                Id = user.Id,
                Name = user.Name,
                Notes = user.Notes,
                Phone = user.Phone,
                Role = user.Role,
                AccessToken = token
            };
        }
    }
}

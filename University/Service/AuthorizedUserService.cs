using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using University.Domain.Contracts;
using University.Domain.Entities.Users;
using University.WebApi.Configurations;

namespace University.WebApi.Service
{
    public class AuthorizedUserService : IAuthorizedUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly JwtSettings _jwtSettings;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public AuthorizedUserService(IHttpContextAccessor contextAccessor, JwtSettings jwtSettings, TokenValidationParameters tokenValidationParameters)
        {
            _contextAccessor = contextAccessor;
            _jwtSettings = jwtSettings;
            _tokenValidationParameters = tokenValidationParameters;
        }

        public ClaimsPrincipal GetAuthorizedUser() => _contextAccessor.HttpContext.User;

        public Guid GetCurrentLecturerId() =>
            Guid.Parse(_contextAccessor
                .HttpContext
                .User
                .Claims
                .First(x => x.Type == "lecturerId").Value);

        public Guid GetCurrentStudentId() =>
            Guid.Parse(_contextAccessor
                .HttpContext
                .User
                .Claims
                .First(x => x.Type == "studentId").Value);

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var roleNumber = (int)user.Role;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("lecturerId", user.LecturerId.ToString()),
                    new Claim("studentId", user.StudentId.ToString()),
                    new Claim("roleKay", roleNumber.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public bool IsAuthorized()
        {
            var authorizedUser = GetAuthorizedUser();

            return authorizedUser != null && authorizedUser.Claims.Count() != 0;
        }

    }
}

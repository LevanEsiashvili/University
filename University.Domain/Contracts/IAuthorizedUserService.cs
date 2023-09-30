using System.Security.Claims;
using University.Domain.Entities.Users;

namespace University.Domain.Contracts
{
    public interface IAuthorizedUserService
    {
        ClaimsPrincipal GetAuthorizedUser();

        bool IsAuthorized();

        Guid GetCurrentLecturerId();

        Guid GetCurrentStudentId();

        string GenerateToken(User user);
    }
}

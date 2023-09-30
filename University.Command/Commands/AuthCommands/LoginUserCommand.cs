using Microsoft.EntityFrameworkCore;
using University.Command.CommandModels.AuthModels;
using University.Domain.Contracts;
using University.Domain.Entities.Lecturers;
using University.Domain.Service;
using University.Infrastructure;
using University.Shared.Models;

namespace University.Command.Commands.AuthCommands
{
    public class LoginUserCommand : CommandBase
    {
        private readonly LoginUserCommandModel _model;
        public LoginUserCommand(RepositoryProvider repositoryProvider, IAuthorizedUserService authorizedUserService, LoginUserCommandModel model) : base(repositoryProvider, authorizedUserService)
        {
            _model = model;
        }

        public override async Task<Result> HandleAsync()
        {
            var user = await _repositoryProvider.Users.GetQueryable()
                .FirstOrDefaultAsync(x => x.Email == _model.Email);

            if (user == null)
            {
                return Result.Error("მომხმარებელი მსგავსი მეილით ვერ მოიძებნა");
            }

            AuthService authService = new AuthService();

            var isVertified = authService.VerifyPasswordHash(_model.Password, user.PasswordHash, user.PasswordSalt);

            if (!isVertified)
            {
                return Result.Error("პაროლი არასწორია");
            }

            var token = _authorizedUserService.GenerateToken(user);

            return Result.Success((object)token);
        }
    }
}

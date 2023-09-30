using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Command.CommandModels.UserModels;
using University.Domain.Entities.Lecturers;
using University.Domain.Entities.Users;
using University.Infrastructure;
using University.Shared.Models;

namespace University.Command.Commands.UserCommands
{
    public class CreateLecturerCommand : CommandBase
    {
        private readonly CreateLecturerCommandModel _model;
        public CreateLecturerCommand(RepositoryProvider repositoryProvider, CreateLecturerCommandModel model) : base(repositoryProvider)
        {
            _model = model;
        }

        public async override Task<Result> HandleAsync()
        {
            var lecturer = new User()
            {
                FirstName = _model.FirstName,
                LastName = _model.LastName,
                BirtsDate = DateTime.Now,
                PrivateNumber = _model.PrivateNumber,
                PhoneNumber = _model.PhoneNumber,
                Email = _model.Email,
                PasswordHash = default,
                PasswordSalt = default,
                Lecturer = new Lecturer()
                {
                    QualificationYare = _model.QualificationYare,
                    Profession = _model.Profession,
                }


            };
            
            _repositoryProvider.Users.Create(lecturer);
            _repositoryProvider.UnitOfWork.SaveChange();

            return Result.Success("ლექტორი წარმატებით შეიქმნა");
            
        }
    }
}

using University.Domain.Contracts;
using University.Infrastructure.Database;

namespace University.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public UniversityDbContext Context { get; set; }

        public UnitOfWork(UniversityDbContext context)
        {
            Context = context;
        }
        public int SaveChange()
        {
           return Context.SaveChanges();
        }
    }
}

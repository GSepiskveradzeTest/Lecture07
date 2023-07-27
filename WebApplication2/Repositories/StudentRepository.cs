using WebApplication2.Entities;
using WebApplication2.Interfaces;

namespace WebApplication2.Repositories
{
    public class StudentRepository : GenericRepository<StudentEntity>, IStudentRepository
    {
        public StudentRepository(
            FirstDbContext context) : base(context)
        {
        }
    }
}

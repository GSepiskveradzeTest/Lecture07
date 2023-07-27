using WebApplication2.Interfaces;

namespace WebApplication2.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IServiceProvider _serviceProvider;

        public UnitOfWork(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
        }

        public IStudentRepository StudentRepository => _serviceProvider.GetRequiredService<StudentRepository>();
    }
}

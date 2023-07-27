namespace WebApplication2.Interfaces
{
    public interface IUnitOfWork
    {
        IStudentRepository StudentRepository { get; }
    }
}

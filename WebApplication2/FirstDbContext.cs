using Microsoft.EntityFrameworkCore;
using WebApplication2.Entities;

namespace WebApplication2
{
    public class FirstDbContext : DbContext
    {
        public FirstDbContext(DbContextOptions<FirstDbContext> options) : base(options) { }

        DbSet<TestEntity> Tests { get; set; }

        DbSet<StudentEntity> Students { get; set; }

        DbSet<StudentClassEntity> StudentClasses { get; set; }

        DbSet<ClassEntity> Classes { get; set; }

        DbSet<TeacherEntity> Teachers { get; set; }

        DbSet<UserEntity> Users { get; set; }

        DbSet<UserDetailEntity> UsersDetail { get; set; }

        DbSet<PostEntity> Posts { get; set; }

        DbSet<CommentEntity> Comments { get; set; }
    }
}

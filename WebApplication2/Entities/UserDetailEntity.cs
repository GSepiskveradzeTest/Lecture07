namespace WebApplication2.Entities
{
    public class UserDetailEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual UserEntity User { get; set; }

        public string UserName { get; set; }

        public string IdNumber { get; set; }
    }
}

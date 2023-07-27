namespace WebApplication2.Entities
{
    public class TeacherEntity : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Bio { get; set; }

        public Guid ClassId { get; set; }
        
        public virtual ClassEntity Class { get; set; }
    }
}

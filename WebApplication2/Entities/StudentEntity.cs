namespace WebApplication2.Entities
{
    public class StudentEntity : BaseEntity
    {
        public string FirstName { get; set; }   

        public string LastName { get; set;  }

        public int IDNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public virtual List<StudentClassEntity> StudentClasses { get; set; }
    }
}

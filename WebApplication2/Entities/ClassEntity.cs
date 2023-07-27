namespace WebApplication2.Entities
{
    public class ClassEntity : BaseEntity
    {
        public int ClassNumber { get; set; }

        public string ClassName { get; set; }

        public virtual List<StudentClassEntity> StudentClasses { get; set; }
    }
}

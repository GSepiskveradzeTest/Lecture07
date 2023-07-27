using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Entities
{
    public class StudentClassEntity : BaseEntity
    {
        public Guid StudentId { get; set; }

        public virtual StudentEntity Student { get; set; }

        public Guid ClassId { get; set; }

        public virtual ClassEntity Class { get; set; }
    }
}

namespace WebApplication2.Entities
{
    public class PostEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual ICollection<CommentEntity> Comments { get; set; }
    }
}

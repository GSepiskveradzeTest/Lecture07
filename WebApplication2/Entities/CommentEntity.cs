namespace WebApplication2.Entities
{
    public class CommentEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int PostId { get; set; }

        public virtual PostEntity Post { get; set; }
    }
}

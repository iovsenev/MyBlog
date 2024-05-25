namespace MyBlog.Domain.Entities
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Article> Articles { get; set; }
    }
}
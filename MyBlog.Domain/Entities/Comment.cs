using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Domain.Entities
{
    public class Comment
    {
        public Guid id { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public DateTimeOffset AddedDate { get; set; }


        public Guid AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public AppUser Author { get; set; }

        public Guid ArticleId { get; set; }
        [ForeignKey(nameof(ArticleId))]
        public Article Article { get; set; }
    }
}
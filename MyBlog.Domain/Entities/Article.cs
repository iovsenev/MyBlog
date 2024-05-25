using CSharpFunctionalExtensions;
using MyBlog.Domain.Common;

namespace MyBlog.Domain.Entities
{
    public class Article
    {
        private Article () { }
        private Article(
            Guid id, 
            string title,
            string description,
            string text, 
            DateTimeOffset addedDate,
            int likes, 
            int dislikes/*, 
            Image? mainImage, 
            IReadOnlyList<Image>? images,
            AppUser author*/
            )
        {
            Id = id;
            Title = title;
            Description = description;
            Text = text;
            AddedDate = addedDate;
            Likes = likes;
            Dislikes = dislikes;
            //MainImage = mainImage;
            //Images = images;
            //Author = author;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public DateTimeOffset AddedDate { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        //public Image? MainImage { get; set; }
        //public IReadOnlyList<Image>? Images { get; set; }

        //public AppUser Author { get; set; }

        //public IReadOnlyList<Comment> Comments { get; set; }
        
        //public IReadOnlyList<Tag> Tags { get; set; }


        public static Result<Article, Error> Create(
            string title,
            string description,
            string text
            )
        {
            var id = Guid.NewGuid();

            if (string.IsNullOrEmpty(title.Trim()))
                return Errors.General.InValid(title);

            if (string.IsNullOrEmpty(description.Trim()))
                return Errors.General.InValid(description);

            if (string.IsNullOrEmpty(text.Trim()))
                return Errors.General.InValid(text);

            var addedDate = DateTimeOffset.Now;

            return new Article(id, title, description, text, addedDate, 0, 0);
        }
    }
}
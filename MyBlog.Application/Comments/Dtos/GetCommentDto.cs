using MyBlog.Application.Articles.Dtos;
using MyBlog.Application.Users.DTOS;
using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Comments.Dtos
{
    public class GetCommentDto
    {
        public Guid Id { get; private set; }
        public string Text { get; private set; }
        public int Likes { get; private set; }
        public int Dislikes { get; private set; }
        public DateTimeOffset AddedDate { get; private set; }


        public AppUserDto Author { get; private set; }

        public GetArticleDto Article { get; private set; }
    }
}

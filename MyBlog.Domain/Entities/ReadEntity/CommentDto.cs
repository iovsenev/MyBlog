using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Entities.ReadEntity;

public class CommentDto
{
    public Guid Id { get; private set; }
    public string Text { get; private set; }
    public int Likes { get; private set; }
    public int Dislikes { get; private set; }
    public DateTimeOffset AddedDate { get; private set; }


    public AppUserDto Author { get; private set; }

    public ArticleDto Article { get; private set; }
}

using MyBlog.Application.Articles.Dtos;
using MyBlog.Application.Comments.Dtos;

namespace MyBlog.Application.Users.DTOS;

public class AppUserDto 
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SecondName { get; set; }
    public DateTimeOffset BirthDate { get; set; }
    public DateTimeOffset RegistrationDate { get; set; }

    public ICollection<GetArticleDto> Articles { get; set; }
    public ICollection<GetCommentDto> Comments { get; set; }
}

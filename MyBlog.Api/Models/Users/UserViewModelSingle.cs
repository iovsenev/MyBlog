using MyBlog.Api.Models.Articles;

namespace MyBlog.Api.Models.Users;

public class UserViewModelSingle(
    Guid Id,
    string UserName,
    string FullName,
    DateTime BirthDate,
    DateTime RegisterDate,
    ICollection<ArticleViewModelForList> Articles);

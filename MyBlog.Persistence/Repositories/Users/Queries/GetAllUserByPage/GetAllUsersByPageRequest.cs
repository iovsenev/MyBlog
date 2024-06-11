namespace MyBlog.Persistence.Repositories.Users.Queries.GetAllUserByPage;
public record GetAllUsersByPageRequest(
    int PageIndex = 1,
    int PageSize = 10);

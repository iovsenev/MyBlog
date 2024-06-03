namespace MyBlog.Persistence.Repositories.Users.Queries;
public record GetAllUsersByPageRequest(
    int PageIndex = 1,
    int PageSize = 10);

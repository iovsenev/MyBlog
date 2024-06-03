namespace MyBlog.Persistence.Repositories.Users.Queries;

public record GetAllUserViewModel(ICollection<ShortUserViewModel> Users);
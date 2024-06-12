namespace MyBlog.Api.Models.Users;

public record GetAllUserViewModel(ICollection<ShortUserViewModel> Users);
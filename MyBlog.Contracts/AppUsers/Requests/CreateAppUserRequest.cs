namespace MyBlog.Contracts.AppUsers.Requests;
public record CreateAppUserRequest(
        string UserName,
        string PasswordHash,
        string Email,
        string Phone,
        string FirstName,
        string LastName,
        string SecondName,
        DateTime BirthDate);

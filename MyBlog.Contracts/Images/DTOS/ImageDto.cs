namespace MyBlog.Contracts.Images.DTOS;
public record ImageDto(
    Guid Id,
    string Path,
    bool IsMain);

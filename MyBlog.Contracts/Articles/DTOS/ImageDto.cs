namespace MyBlog.Contracts.Articles.DTOS;
public record ImageDto(
    Guid Id, 
    string Path, 
    bool IsMain);

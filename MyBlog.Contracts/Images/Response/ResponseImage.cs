using MyBlog.Contracts.Images.DTOS;

namespace MyBlog.Contracts.Images.Response;
public record ResponseImage(IEnumerable<ImageDto> Images);

namespace MyBlog.Domain.Entities;
public class Image
{
    private Image()
    {
    }

    private Image(Guid id, string path)
    {
        Id = id;
        Path = path;
    }

    public Guid Id { get; private set; }
    public string Path { get; private set; }
    public bool IsMain { get; private set; }
}

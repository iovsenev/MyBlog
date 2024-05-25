namespace MyBlog.Contracts.Articles.Response
{
    public record ResponseArticle(
        Guid Id,
        string Tittle,
        string Description,
        string Text,
        int Likes,
        int Dislikes,
        DateTimeOffset AddedDate,
        string AutorName
        );

}
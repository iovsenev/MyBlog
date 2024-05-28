namespace MyBlog.Application.Interfaces.Services
{
    public interface IMediator
    {
        void Send(IRequest request);
    }
}

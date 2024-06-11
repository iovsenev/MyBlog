using Microsoft.Extensions.Configuration;
using Moq;
using MyBlog.Persistence.DbContexts;

namespace MyBlog.Tests;
public static class CreateDbContext
{
    public static AppReadDbContext GetAppReadDbContext()
    {
        var moqContext = new Mock<IConfiguration>();
        moqContext.Setup(m =>m.GetConnectionString("testDb")).Returns())
        var context = new AppReadDbContext(moqContext.Object);
    }

}



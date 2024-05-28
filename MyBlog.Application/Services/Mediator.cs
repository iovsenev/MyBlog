using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity.Data;
using MyBlog.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Services
{
    public class Mediator : IMediator
    {
        public IRequestHandler<IRequest, Result> Send(IRequest request)
        {
            var assembly = typeof(IRequest).Assembly;
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                        .Any(i => i.IsGenericType &&
                        i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                .FirstOrDefault();
            return (IRequestHandler < IRequest, Result >)types;
        }
    }

    public interface IRequest
    {
    }
}

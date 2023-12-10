using System.Reflection;
using CustomMediator.Library.Abstractions;

namespace CustomMediator.Library.Concretes;

public class Mediator : IMediator
{
    public Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
    {
        var typeTypeInterface = request.GetType().GetInterfaces().Where(i=>i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequest<>)).FirstOrDefault();
        var responseType = typeTypeInterface.GetGenericArguments()[0];
        var genericType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(),responseType);
        var types = AssembliesData.AssaAssemblies.SelectMany(p => p.GetTypes()).Where(x=>!x.IsInterface).ToList();
        var reqHandler = types.Where(i=>i.GetInterfaces().Any(x=> x == genericType)).FirstOrDefault();
        if (reqHandler is null)
        {
            throw new Exception("Must be not null");
        }
        // Type nesnesi üzerinden bir instance oluşturun
        var myClassInstance = Activator.CreateInstance(reqHandler);
        return (Task<TResponse>)genericType.GetMethod("Handle").Invoke(myClassInstance,new[] { request });
    }
}
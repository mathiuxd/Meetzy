using System.Reflection;
using Meetzy.Application.Exceptions;

namespace Meetzy.Application.Utilities.Mediator
{
    public class SimpleMediator(IServiceProvider serviceProvider) : IMediator
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        { 
            Type useCaseType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));

            var useCase = _serviceProvider.GetService(useCaseType) ?? throw new MediatorException($"No se encontró un handler para {request.GetType().Name}");
            MethodInfo method = useCaseType.GetMethod("Handle")!;

            return await (Task<TResponse>)method.Invoke(useCase, [request])!;
        }
        

        public async Task Send(IRequest request)
        {
            Type useCaseType = typeof(IRequestHandler<>).MakeGenericType(request.GetType());

            var useCase = _serviceProvider.GetService(useCaseType) ?? throw new MediatorException($"No se encontró un handler para {request.GetType().Name}");
            
            MethodInfo method = useCaseType.GetMethod("Handle")!;

            await (Task)method.Invoke(useCase, [request])!;
        }
    }
}

using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastucture.Caching
{
    public class CachingHandler<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //TODO Redis cacher
            return await next();
        }
    }
}

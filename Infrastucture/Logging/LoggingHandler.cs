using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastucture.Logging
{
    public class LoggingHandler<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public LoggingHandler(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");
            var response = await next();
            _logger.LogInformation($"Handled result: {JsonConvert.SerializeObject(response)}");

            return response;
        }
    }
}

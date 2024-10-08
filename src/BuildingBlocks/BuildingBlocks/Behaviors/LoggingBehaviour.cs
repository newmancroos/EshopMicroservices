using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Behaviors
{
    public class LoggingBehaviour<TRequest, TResponse>
        (ILogger<LoggingBehaviour<TRequest, TResponse>> logger) 
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull, IRequest<TResponse>
        where TResponse : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("[START] handler request = {Request} - Resp[onse = {Response} - RequestData-{RequestData}", 
                typeof(TRequest).Name, typeof(TResponse).Name, request);

            var timer = new Stopwatch();
            timer.Start();

            var response = await next();

            timer.Stop();

            var timeTaken = timer.Elapsed;

            if(timeTaken.Seconds > 3)
                logger.LogWarning("[PERFORMANCE] the request {Request} took {TimeTaken} Seconds", typeof(TRequest).Name, timeTaken.Seconds);

            logger.LogInformation("[END] handled {Request} with {Response}", typeof(TRequest), typeof(TResponse));

            return response;

        }
    }
}

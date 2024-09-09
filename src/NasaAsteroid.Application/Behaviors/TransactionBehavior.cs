using MediatR;
using Microsoft.Extensions.Logging;
using NasaAsteroid.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAsteroid.Application.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TransactionBehavior<TRequest, TResponse>> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionBehavior(IUnitOfWork unitOfWork, ILogger<TransactionBehavior<TRequest, TResponse>> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Guid? transactionId = null;

            try
            {
                if (_unitOfWork.HasTransaction)
                {
                    return await next();
                }

                transactionId = await _unitOfWork.BeginTransactionAsync(cancellationToken);

                _logger.LogInformation($"Create transaction id - {transactionId}.");

                TResponse response = await next();

                await _unitOfWork.CommitAsync(cancellationToken);

                _logger.LogInformation($"Transaction id - {transactionId} commited.");

                return response;
            }
            catch( Exception ex )
            {
                if( transactionId != null)
                {
                    await _unitOfWork.RollbackAsync(cancellationToken);
                    _logger.LogError(ex, $"Error handling transaction id - {transactionId.Value}");
                }

                throw;
            }
        }
    }
}

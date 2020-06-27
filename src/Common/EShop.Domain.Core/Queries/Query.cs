using FluentValidation.Results;
using MediatR;

namespace EShop.Domain.Core.Queries
{
    public abstract class Query<TResponse> : IRequest<TResponse>
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}

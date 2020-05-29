using EShop.Domain.Core.Messages;
using FluentValidation.Results;

namespace EShop.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}

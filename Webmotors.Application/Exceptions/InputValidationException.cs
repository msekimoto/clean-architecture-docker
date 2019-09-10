using Webmotors.Domain;

namespace Webmotors.Application.Exceptions
{
    public sealed class InputValidationException : DomainException
    {
        public InputValidationException(string message) : base(message) { }
    }
}
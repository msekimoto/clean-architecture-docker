namespace Webmotors.Domain
{
    public sealed class ValidationFailException : DomainException
    {
        internal ValidationFailException(string message) : base(message) { }
    }
}
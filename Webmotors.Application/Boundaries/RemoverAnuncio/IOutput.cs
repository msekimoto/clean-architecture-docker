namespace Webmotors.Application.Boundaries.RemoverAnuncio
{
    public interface IOutput : IErrorHandler
    {
        void Default();
        void NotFound(string message);
    }
}

namespace Webmotors.Application.Boundaries.IncluirAnuncio
{
    public interface IOutput : IErrorHandler
    {
        void Default(IncluirAnuncioOutput incluirAnuncioOutput);
        void NotFound(string message);
    }
}

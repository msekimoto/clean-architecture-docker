namespace Webmotors.Application.Boundaries.ConsultarAnuncio
{
    public interface IOutput : IErrorHandler
    {
        void Default(ConsultarAnuncioOutput consultarAnuncioOutput);
        void NotFound(string message);
    }
}

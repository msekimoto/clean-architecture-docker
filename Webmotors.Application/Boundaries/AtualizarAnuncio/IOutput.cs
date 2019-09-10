namespace Webmotors.Application.Boundaries.AtualizarAnuncio
{
    public interface IOutput : IErrorHandler
    {
        void Default(AtualizarAnuncioOutput atualizarAnuncioOutput);
        void NotFound(string message);
    }
}

namespace Webmotors.Application.Boundaries.ListarMarcasVeiculo
{
    public interface IOutput : IErrorHandler
    {
        void Default(ListarMarcasVeiculoOutput listarMarcasVeiculoOutput);
        void NotFound(string message);
    }
}

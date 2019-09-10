namespace Webmotors.Application.Boundaries.ListarModelosVeiculo
{
    public interface IOutput : IErrorHandler
    {
        void Default(ListarModelosVeiculoOutput listarModelosVeiculoOutput);
        void NotFound(string message);
    }
}

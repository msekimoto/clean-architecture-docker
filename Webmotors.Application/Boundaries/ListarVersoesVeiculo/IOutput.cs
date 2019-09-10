namespace Webmotors.Application.Boundaries.ListarVersoesVeiculo
{
    public interface IOutput : IErrorHandler
    {
        void Default(ListarVersoesVeiculoOutput listarVersoesVeiculoOutput);
        void NotFound(string message);
    }
}

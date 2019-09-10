using System.Threading.Tasks;

namespace Webmotors.Application.Boundaries.ListarVersoesVeiculo
{
    public interface IUseCase
    {
        Task Execute(ListarVersoesVeiculoInput listarVersoesVeiculoInput);
    }
}

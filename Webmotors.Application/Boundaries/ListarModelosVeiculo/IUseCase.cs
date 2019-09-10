using System.Threading.Tasks;

namespace Webmotors.Application.Boundaries.ListarModelosVeiculo
{
    public interface IUseCase
    {
        Task Execute(ListarModelosVeiculoInput listarModelosInput);
    }
}

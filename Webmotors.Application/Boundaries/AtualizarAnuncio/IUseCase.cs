using System.Threading.Tasks;

namespace Webmotors.Application.Boundaries.AtualizarAnuncio
{
    public interface IUseCase
    {
        Task Execute(AtualizarAnuncioInput atualizarAnuncioInput);
    }
}

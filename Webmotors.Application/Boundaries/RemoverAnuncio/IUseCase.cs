using System.Threading.Tasks;
using Webmotors.Application.Boundaries.AtualizarAnuncio;

namespace Webmotors.Application.Boundaries.RemoverAnuncio
{
    public interface IUseCase
    {
        Task Execute(RemoverAnuncioInput removerAnuncioInput);
    }
}

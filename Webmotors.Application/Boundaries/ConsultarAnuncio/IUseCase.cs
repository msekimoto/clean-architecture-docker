using System.Threading.Tasks;
using Webmotors.Application.Boundaries.ConsultarAnuncio;

namespace Webmotors.Application.Boundaries.ConsultarAnuncio
{
    public interface IUseCase
    {
        Task Execute(ConsultarAnuncioInput consultarAnuncioInput);
    }
}

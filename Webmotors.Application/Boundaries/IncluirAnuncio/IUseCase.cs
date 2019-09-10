using System.Threading.Tasks;
using Webmotors.Domain.Anuncios;

namespace Webmotors.Application.Boundaries.IncluirAnuncio
{
    public interface IUseCase
    {
        Task Execute(IncluirAnuncioInput incluirAnuncioInput);
    }
}

using System.Threading.Tasks;
using Webmotors.Domain.Anuncios;

namespace Webmotors.Application.Repositories
{
    public interface IAnuncioRepository
    {
        Task<IAnuncio> Get(int id);
        Task Add(IAnuncio anuncio);
        Task Update(IAnuncio anuncio);
        Task Delete(IAnuncio anuncio);
    }
}
using Webmotors.Domain;
using Webmotors.Domain.Anuncios;
using Anuncio = Webmotors.Infrastructure.Entities.Anuncio;

namespace Webmotors.Infrastructure.Factories
{
    public class EntityFactory : IEntityFactory
    {
        public IAnuncio NovoAnuncio(string marca, string modelo, string versao, int ano, int quilometragem, string observacao)
        {
            return new Anuncio(marca, modelo, versao, ano, quilometragem, observacao);
        }
    }
}
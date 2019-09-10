using Webmotors.Domain.Anuncios;

namespace Webmotors.Domain
{
    public interface IEntityFactory
    {
        IAnuncio NovoAnuncio(string marca, string modelo, string versao, int ano, int quilometragem, string observacao);
    }
}
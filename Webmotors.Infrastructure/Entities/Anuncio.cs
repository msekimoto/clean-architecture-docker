using Webmotors.Domain.Anuncios;

namespace Webmotors.Infrastructure.Entities
{
    public class Anuncio : Domain.Anuncios.Anuncio
    {
        public Anuncio(string marca, string modelo, string versao, int ano, int quilometragem, string observacao) 
            : base(marca, modelo, versao, ano, quilometragem, observacao) { }
    }
}
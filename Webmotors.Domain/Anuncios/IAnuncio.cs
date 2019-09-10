namespace Webmotors.Domain.Anuncios
{
    public interface IAnuncio : IEntity
    {
        string Marca { get; }
        string Modelo { get; }
        string Versao { get; }
        int Ano { get; }
        int Quilometragem { get; }
        string Observacao { get; }

        void AtualizarAnuncio(string marca, string modelo, string versao, int ano, int quilometragem, string observacao);
        bool IsValid();

    }
}
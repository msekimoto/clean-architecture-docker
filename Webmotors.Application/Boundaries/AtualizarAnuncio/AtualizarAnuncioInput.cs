namespace Webmotors.Application.Boundaries.AtualizarAnuncio
{
    public sealed class AtualizarAnuncioInput
    {
        public int Id { get; set; }
        public int IdMarca { get; }
        public int IdModelo { get; }
        public int IdVersao { get; }
        public int Ano { get; }
        public int Quilometragem { get; }
        public string Observacao { get; }

        public AtualizarAnuncioInput(int id, int idMarca, int idModelo, int idVersao, int ano, int quilometragem, string observacao)
        {
            Id = id;
            IdMarca = idMarca;
            IdModelo = idModelo;
            IdVersao = idVersao;
            Ano = ano;
            Quilometragem = quilometragem;
            Observacao = observacao;
        }
    }
}
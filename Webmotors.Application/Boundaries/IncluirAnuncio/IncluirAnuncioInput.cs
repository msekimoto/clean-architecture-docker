using Webmotors.Application.Exceptions;

namespace Webmotors.Application.Boundaries.IncluirAnuncio
{
    public sealed class IncluirAnuncioInput
    {
        public int IdMarca { get; }
        public int IdModelo { get; }
        public int IdVersao { get; }
        public int Ano { get; }
        public int Quilometragem { get; }
        public string Observacao { get; }

        public IncluirAnuncioInput(int idMarca, int idModelo, int idVersao, int ano, int quilometragem, string observacao)
        {
            IdMarca = idMarca;
            IdModelo = idModelo;
            IdVersao = idVersao;
            Ano = ano;
            Quilometragem = quilometragem;
            Observacao = observacao;
        }
    }
}
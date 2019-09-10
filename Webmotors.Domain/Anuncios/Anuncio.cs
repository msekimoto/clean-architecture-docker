using System;
using Webmotors.Domain.Veiculos;

namespace Webmotors.Domain.Anuncios
{
    public class Anuncio : IAnuncio
    {
        public int ID { get; protected set; }
        public string Marca { get; protected set; }
        public string Modelo { get; protected set; }
        public string Versao { get; protected set; }
        public int Ano { get; protected set; }
        public int Quilometragem { get; protected set; }
        public string Observacao { get; protected set; }

        protected internal Anuncio() { }

        public Anuncio(string marca, string modelo, string versao, int ano, int quilometragem, string observacao)
        {
            Marca = marca;
            Modelo = modelo;
            Versao = versao;
            Ano = ano;
            Quilometragem = quilometragem;
            Observacao = observacao;

            IsValid();
        }

        public void AtualizarAnuncio(string marca, string modelo, string versao, int ano, int quilometragem, string observacao)
        {
            Marca = marca;
            Modelo = modelo;
            Versao = versao;
            Ano = ano;
            Quilometragem = quilometragem;
            Observacao = observacao;

            IsValid();
        }

        public bool IsValid()
        {
            var validator = new AnuncioValidator();
            var results = validator.Validate(this);

            if (results.IsValid)
                return true;

            throw new ValidationFailException(String.Concat(results.Errors));
        }
    }
}
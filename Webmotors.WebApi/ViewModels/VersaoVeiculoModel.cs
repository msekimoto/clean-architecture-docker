using System.ComponentModel.DataAnnotations;

namespace Webmotors.WebApi.ViewModels
{
    public class VersaoVeiculoModel
    {
        [Required]
        public int Codigo { get; }

        [Required]
        public int CodigoModelo { get; }

        [Required]
        public string Nome { get; }

        public VersaoVeiculoModel(int idVersao, int idModelo, string nome)
        {
            Codigo = idVersao;
            CodigoModelo = idModelo;
            Nome = nome;
        }
    }
}
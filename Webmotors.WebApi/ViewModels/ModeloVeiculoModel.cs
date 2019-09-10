using System.ComponentModel.DataAnnotations;

namespace Webmotors.WebApi.ViewModels
{
    public class ModeloVeiculoModel
    {
        [Required]
        public int Codigo { get; }

        [Required]
        public int CodigoMarca { get; }

        [Required]
        public string Nome { get; }

        public ModeloVeiculoModel(int idModelo, int idMarca, string nome)
        {
            Codigo = idModelo;
            CodigoMarca = idMarca;
            Nome = nome;
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Webmotors.WebApi.ViewModels
{
    public class MarcaVeiculoModel
    {
        [Required]
        public int Codigo { get; }

        [Required]
        public string Nome { get; }

        public MarcaVeiculoModel(int idMarca, string nome)
        {
            Codigo = idMarca;
            Nome = nome;
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Webmotors.WebApi.UseCases.V1.ListarModelosVeiculo
{
    public sealed class ListarModelosVeiculoRequest
    {
        [Required]
        public int IdMarca { get; set; }
    }
}
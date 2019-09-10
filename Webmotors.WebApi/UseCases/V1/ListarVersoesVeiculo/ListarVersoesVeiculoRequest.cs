using System.ComponentModel.DataAnnotations;

namespace Webmotors.WebApi.UseCases.V1.ListarVersoesVeiculo
{
    public sealed class ListarVersoesVeiculoRequest
    {
        [Required]
        public int IdModelo { get; set; }
    }
}
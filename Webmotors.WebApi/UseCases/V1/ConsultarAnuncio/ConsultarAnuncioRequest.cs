using System.ComponentModel.DataAnnotations;

namespace Webmotors.WebApi.UseCases.V1.ConsultarAnuncio
{
    public sealed class ConsultarAnuncioRequest
    {
        [Required]
        public int IdAnuncio { get; set; }
    }
}
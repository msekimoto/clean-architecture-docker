using System.ComponentModel.DataAnnotations;

namespace Webmotors.WebApi.UseCases.V1.RemoverAnuncio
{
    public sealed class RemoverAnuncioRequest
    {
        [Required]
        public int IdAnuncio { get; set; }
    }
}
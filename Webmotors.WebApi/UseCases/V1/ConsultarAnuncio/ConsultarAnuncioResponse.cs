using System.ComponentModel.DataAnnotations;
using Webmotors.WebApi.ViewModels;

namespace Webmotors.WebApi.UseCases.V1.ConsultarAnuncio
{
    public sealed class ConsultarAnuncioResponse
    {
        [Required]
        public AnuncioModel AnuncioModel { get; }

        public ConsultarAnuncioResponse(AnuncioModel anuncioModel)
        {
            AnuncioModel = anuncioModel;
        }
    }
}
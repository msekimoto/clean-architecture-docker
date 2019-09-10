using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Webmotors.WebApi.ViewModels;

namespace Webmotors.WebApi.UseCases.V1.AtualizarAnuncio
{
    public sealed class AtualizarAnuncioResponse
    {
        [Required]
        public AnuncioModel AnuncioModel { get; }

        public AtualizarAnuncioResponse(AnuncioModel anuncioModel)
        {
            AnuncioModel = anuncioModel;
        }
    }
}
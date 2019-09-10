using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Webmotors.WebApi.ViewModels;

namespace Webmotors.WebApi.UseCases.V1.IncluirAnuncio
{
    public sealed class IncluirAnuncioResponse
    {
        [Required]
        public AnuncioModel IncluirAnuncioModel { get; }

        public IncluirAnuncioResponse(AnuncioModel incluirAnuncioModel)
        {
            IncluirAnuncioModel = incluirAnuncioModel;
        }
    }
}
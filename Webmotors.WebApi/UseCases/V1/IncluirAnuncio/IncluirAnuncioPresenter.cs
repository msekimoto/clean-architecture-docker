using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Webmotors.Application.Boundaries.IncluirAnuncio;
using Webmotors.WebApi.ViewModels;

namespace Webmotors.WebApi.UseCases.V1.IncluirAnuncio
{
    public sealed class IncluirAnuncioPresenter : IOutput
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails
            {
                Title = "An error occurred",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public void Default(IncluirAnuncioOutput incluirAnuncioOutput)
        {
            var anuncio = new AnuncioModel
            {
                ID = incluirAnuncioOutput.Anuncio.ID,
                Marca = incluirAnuncioOutput.Anuncio.Marca,
                Modelo = incluirAnuncioOutput.Anuncio.Modelo,
                Versao = incluirAnuncioOutput.Anuncio.Versao,
                Ano = incluirAnuncioOutput.Anuncio.Ano,
                Quilometragem = incluirAnuncioOutput.Anuncio.Quilometragem,
                Observacao = incluirAnuncioOutput.Anuncio.Observacao
            };

            var incluirAnuncioResponse = new IncluirAnuncioResponse(anuncio);

            ViewModel = new OkObjectResult(incluirAnuncioResponse);
        }

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }
    }
}
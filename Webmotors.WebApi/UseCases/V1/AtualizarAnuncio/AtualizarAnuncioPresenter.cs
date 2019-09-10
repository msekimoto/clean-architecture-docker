using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Webmotors.Application.Boundaries.AtualizarAnuncio;
using Webmotors.WebApi.ViewModels;

namespace Webmotors.WebApi.UseCases.V1.AtualizarAnuncio
{
    public sealed class AtualizarAnuncioPresenter : IOutput
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

        public void Default(AtualizarAnuncioOutput atualizarAnuncioOutput)
        {
            var anuncio = new AnuncioModel
            {
                ID = atualizarAnuncioOutput.Anuncio.ID,
                Marca = atualizarAnuncioOutput.Anuncio.Marca,
                Modelo = atualizarAnuncioOutput.Anuncio.Modelo,
                Versao = atualizarAnuncioOutput.Anuncio.Versao,
                Ano = atualizarAnuncioOutput.Anuncio.Ano,
                Quilometragem = atualizarAnuncioOutput.Anuncio.Quilometragem,
                Observacao = atualizarAnuncioOutput.Anuncio.Observacao
            };

            var atualizarAnuncioResponse = new AtualizarAnuncioResponse(anuncio);

            ViewModel = new OkObjectResult(atualizarAnuncioResponse);
        }

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }
    }
}
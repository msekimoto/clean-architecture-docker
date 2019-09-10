using Microsoft.AspNetCore.Mvc;
using Webmotors.Application.Boundaries.ConsultarAnuncio;
using Webmotors.WebApi.ViewModels;

namespace Webmotors.WebApi.UseCases.V1.ConsultarAnuncio
{
    public sealed class ConsultarAnuncioPresenter : IOutput
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

        public void Default(ConsultarAnuncioOutput consultarAnuncioOutput)
        {
            var anuncio = new AnuncioModel
            {
                ID = consultarAnuncioOutput.Anuncio.ID,
                Marca = consultarAnuncioOutput.Anuncio.Marca,
                Modelo = consultarAnuncioOutput.Anuncio.Modelo,
                Versao = consultarAnuncioOutput.Anuncio.Versao,
                Ano = consultarAnuncioOutput.Anuncio.Ano,
                Quilometragem = consultarAnuncioOutput.Anuncio.Quilometragem,
                Observacao = consultarAnuncioOutput.Anuncio.Observacao
            };

            var consultarAnuncioResponse = new ConsultarAnuncioResponse(anuncio);

            ViewModel = new OkObjectResult(consultarAnuncioResponse);
        }

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }
    }
}
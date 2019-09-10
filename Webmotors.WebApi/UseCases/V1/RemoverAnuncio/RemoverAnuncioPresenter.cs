using Microsoft.AspNetCore.Mvc;
using Webmotors.Application.Boundaries.RemoverAnuncio;
using Webmotors.WebApi.ViewModels;

namespace Webmotors.WebApi.UseCases.V1.RemoverAnuncio
{
    public sealed class RemoverAnuncioPresenter : IOutput
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

        public void Default()
        {
            ViewModel = new OkObjectResult($"Excluido com Sucesso.");
        }

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }
    }
}
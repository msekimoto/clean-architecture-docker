using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Webmotors.Application.Boundaries.ListarMarcasVeiculo;
using Webmotors.WebApi.ViewModels;

namespace Webmotors.WebApi.UseCases.V1.ListarMarcasVeiculo
{
    public sealed class ListarMarcasVeiculoPresenter : IOutput
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

        public void Default(ListarMarcasVeiculoOutput listarMarcasOutput)
        {
            List<MarcaVeiculoModel> marcas = new List<MarcaVeiculoModel>();

            foreach (var marca in listarMarcasOutput.Marcas)
            {
                marcas.Add(new MarcaVeiculoModel(
                    marca.ID,
                    marca.Name));
            }

            var listarMarcasVeiculoResponse = new ListarMarcasVeiculoResponse(marcas);

            ViewModel = new OkObjectResult(listarMarcasVeiculoResponse);
        }

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }
    }
}
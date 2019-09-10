using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Webmotors.Application.Boundaries.ListarModelosVeiculo;
using Webmotors.WebApi.ViewModels;

namespace Webmotors.WebApi.UseCases.V1.ListarModelosVeiculo
{
    public sealed class ListarModelosVeiculoPresenter : IOutput
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

        public void Default(ListarModelosVeiculoOutput listarModelosOutput)
        {
            List<ModeloVeiculoModel> modelos = new List<ModeloVeiculoModel>();

            foreach (var modelo in listarModelosOutput.Modelos)
            {
                modelos.Add(new ModeloVeiculoModel(
                    modelo.ID,
                    modelo.MakeID,
                    modelo.Name));
            }

            var listarModelosVeiculoResponse = new ListarModelosVeiculoResponse(modelos);

            ViewModel = new OkObjectResult(listarModelosVeiculoResponse);
        }

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Webmotors.Application.Boundaries.ListarVersoesVeiculo;
using Webmotors.WebApi.ViewModels;

namespace Webmotors.WebApi.UseCases.V1.ListarVersoesVeiculo
{
    public sealed class ListarVersoesVeiculoPresenter : IOutput
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

        public void Default(ListarVersoesVeiculoOutput listarModelosOutput)
        {
            List<VersaoVeiculoModel> versoes = new List<VersaoVeiculoModel>();

            foreach (var versao in listarModelosOutput.Versoes)
            {
                versoes.Add(new VersaoVeiculoModel(
                    versao.ID,
                    versao.ModelID,
                    versao.Name));
            }

            var listarVersoesVeiculoResponse = new ListarVersoesVeiculoResponse(versoes);

            ViewModel = new OkObjectResult(listarVersoesVeiculoResponse);
        }

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webmotors.Application.Boundaries.ListarModelosVeiculo;
using Webmotors.Application.Services.Interfaces;
using Webmotors.Domain.Veiculos;

namespace Webmotors.Application.UseCases
{
    public class ListarModelosVeiculoUseCase : IUseCase
    {
        private readonly IOutput _outputHandler;
        private readonly IModeloVeiculoService _modeloVeiculoService;

        public ListarModelosVeiculoUseCase(IOutput outputHandler, IModeloVeiculoService modeloVeiculoService)
        {
            _outputHandler = outputHandler;
            _modeloVeiculoService = modeloVeiculoService;
        }

        public async Task Execute(ListarModelosVeiculoInput listarModelosInput)
        {
            List<ModeloVeiculo> modelos = await _modeloVeiculoService.Buscar(listarModelosInput.IdMarcaVeiculo);

            if (modelos == null || !modelos.Any())
            {
                _outputHandler.NotFound($"Nenhum modelo para a marca selecionada.");
                return;
            }

            ListarModelosVeiculoOutput listarMarcasOutput = new ListarModelosVeiculoOutput(modelos);
            _outputHandler.Default(listarMarcasOutput);
        }
    }
}

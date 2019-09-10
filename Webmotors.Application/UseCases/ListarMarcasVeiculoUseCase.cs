using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webmotors.Application.Boundaries.ListarMarcasVeiculo;
using Webmotors.Application.Services.Interfaces;
using Webmotors.Domain.Veiculos;

namespace Webmotors.Application.UseCases
{
    public sealed class ListarMarcasVeiculoUseCase : IUseCase
    {
        private IMarcaVeiculoService _marcaVeiculoService;
        private readonly IOutput _outputHandler;

        public ListarMarcasVeiculoUseCase(IOutput outputHandler, IMarcaVeiculoService marcaVeiculoService)
        {
            _marcaVeiculoService = marcaVeiculoService;
            _outputHandler = outputHandler;
        }

        public async Task Execute()
        {
            List<MarcaVeiculo> marcas = await _marcaVeiculoService.Buscar();

            if (marcas == null || !marcas.Any())
            {
                _outputHandler.NotFound($"Nenhuma marca disponivel.");
                return;
            }

            ListarMarcasVeiculoOutput listarMarcasOutput = new ListarMarcasVeiculoOutput(marcas);
            _outputHandler.Default(listarMarcasOutput);
        }
    }
}

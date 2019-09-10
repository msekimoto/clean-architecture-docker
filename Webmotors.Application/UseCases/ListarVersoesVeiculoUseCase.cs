using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webmotors.Application.Boundaries.ListarVersoesVeiculo;
using Webmotors.Application.Services.Interfaces;
using Webmotors.Domain.Veiculos;

namespace Webmotors.Application.UseCases
{
    public class ListarVersoesVeiculoUseCase : IUseCase
    {
        private readonly IOutput _outputHandler;
        private readonly IVersaoVeiculoService _versaoVeiculoService;

        public ListarVersoesVeiculoUseCase(IOutput outputHandler, IVersaoVeiculoService versaoVeiculoService)
        {
            _outputHandler = outputHandler;
            _versaoVeiculoService = versaoVeiculoService;
        }

        public async Task Execute(ListarVersoesVeiculoInput listarVersoesVeiculoInput)
        {
            List<VersaoVeiculo> versoes = await _versaoVeiculoService.Buscar(listarVersoesVeiculoInput.IdModeloVeiculo);

            if (versoes == null || !versoes.Any())
            {
                _outputHandler.NotFound($"Nenhum modelo para a marca selecionada.");
                return;
            }

            ListarVersoesVeiculoOutput listarVersoesVeiculoOutput = new ListarVersoesVeiculoOutput(versoes);
            _outputHandler.Default(listarVersoesVeiculoOutput);
        }
    }
}

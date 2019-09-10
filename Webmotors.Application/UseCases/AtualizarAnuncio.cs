using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webmotors.Application.Boundaries.AtualizarAnuncio;
using Webmotors.Application.Repositories;
using Webmotors.Application.Services.Interfaces;
using Webmotors.Domain.Anuncios;
using Webmotors.Domain.Veiculos;

namespace Webmotors.Application.UseCases
{
    public class AtualizarAnuncio : IUseCase
    {
        private readonly IOutput _outputHandler;
        private readonly IMarcaVeiculoService _marcaVeiculoService;
        private readonly IModeloVeiculoService _modeloVeiculoService;
        private readonly IVersaoVeiculoService _versaoVeiculoService;
        private readonly IAnuncioRepository _anuncioRepository;

        public AtualizarAnuncio(
            IOutput outputHandler,
            IMarcaVeiculoService marcaVeiculoService,
            IModeloVeiculoService modeloVeiculoService,
            IVersaoVeiculoService versaoVeiculoService,
            IAnuncioRepository anuncioRepository)
        {
            _outputHandler = outputHandler;
            _marcaVeiculoService = marcaVeiculoService;
            _modeloVeiculoService = modeloVeiculoService;
            _versaoVeiculoService = versaoVeiculoService;
            _anuncioRepository = anuncioRepository;
        }

        public async Task Execute(AtualizarAnuncioInput incluirAnuncioInput)
        {
            if (incluirAnuncioInput.Id == 0)
            {
                _outputHandler.NotFound($"Codigo do anuncio inválido.");
                return;
            }

            var anuncio = await _anuncioRepository.Get(incluirAnuncioInput.Id);

            if (anuncio == null)
            {
                _outputHandler.NotFound($"Anuncio não encontrado.");
                return;
            }

            List<MarcaVeiculo> marcas = await _marcaVeiculoService.Buscar();
            var marcaSelecionada = marcas.FirstOrDefault(marca => marca.ID == incluirAnuncioInput.IdMarca);
            if (marcaSelecionada == null)
            {
                _outputHandler.NotFound($"Marca selecionada inválida.");
                return;
            }

            List<ModeloVeiculo> modelos = await _modeloVeiculoService.Buscar(marcaSelecionada.ID);
            var modeloSelecionado = modelos.FirstOrDefault(modelo => modelo.ID == incluirAnuncioInput.IdModelo && modelo.MakeID == incluirAnuncioInput.IdMarca);
            if (modeloSelecionado == null)
            {
                _outputHandler.NotFound($"Modelo selecionado inválido.");
                return;
            }

            List<VersaoVeiculo> versoes = await _versaoVeiculoService.Buscar(modeloSelecionado.ID);
            var versaoSelecionada = versoes.FirstOrDefault(versao => versao.ID == incluirAnuncioInput.IdVersao && versao.ModelID == incluirAnuncioInput.IdModelo);
            if (versaoSelecionada == null)
            {
                _outputHandler.NotFound($"Versão selecionada inválida.");
                return;
            }

            anuncio.AtualizarAnuncio(
                marcaSelecionada.Name,
                modeloSelecionado.Name,
                versaoSelecionada.Name,
                incluirAnuncioInput.Ano,
                incluirAnuncioInput.Quilometragem,
                incluirAnuncioInput.Observacao);

            await _anuncioRepository.Update(anuncio);

            AtualizarAnuncioOutput atualizarAnuncioOutput = new AtualizarAnuncioOutput(anuncio);
            _outputHandler.Default(atualizarAnuncioOutput);
        }
    }
}

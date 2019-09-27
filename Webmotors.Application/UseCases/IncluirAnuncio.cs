using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webmotors.Application.Boundaries.IncluirAnuncio;
using Webmotors.Application.Repositories;
using Webmotors.Application.Services.Interfaces;
using Webmotors.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Webmotors.Domain.Veiculos;
using IOutput = Webmotors.Application.Boundaries.IncluirAnuncio.IOutput;
using IUseCase = Webmotors.Application.Boundaries.IncluirAnuncio.IUseCase;

namespace Webmotors.Application.UseCases
{
    public class IncluirAnuncio : IUseCase
    {
        private readonly IConfiguration _config;
        private readonly IDistributedCache _cache;
        private readonly IOutput _outputHandler;
        private readonly IMarcaVeiculoService _marcaVeiculoService;
        private readonly IModeloVeiculoService _modeloVeiculoService;
        private readonly IVersaoVeiculoService _versaoVeiculoService;
        private readonly IAnuncioRepository _anuncioRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityFactory _entityFactory;

        public IncluirAnuncio(
            IOutput outputHandler,
            IMarcaVeiculoService marcaVeiculoService,
            IModeloVeiculoService modeloVeiculoService,
            IVersaoVeiculoService versaoVeiculoService,
            IAnuncioRepository anuncioRepository,
            IUnitOfWork unitOfWork,
            IEntityFactory entityFactory,
            IConfiguration config,
            IDistributedCache cache)
        {
            _config = config;
            _cache = cache;
            _outputHandler = outputHandler;
            _marcaVeiculoService = marcaVeiculoService;
            _modeloVeiculoService = modeloVeiculoService;
            _versaoVeiculoService = versaoVeiculoService;
            _anuncioRepository = anuncioRepository;
            _unitOfWork = unitOfWork;
            _entityFactory = entityFactory;
        }

        public async Task Execute(IncluirAnuncioInput incluirAnuncioInput)
        {
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

            var anuncio = _entityFactory.NovoAnuncio(
                marcaSelecionada.Name,
                modeloSelecionado.Name,
                versaoSelecionada.Name,
                incluirAnuncioInput.Ano,
                incluirAnuncioInput.Quilometragem,
                incluirAnuncioInput.Observacao);

            await _anuncioRepository.Add(anuncio);
            
            if(anuncio.ID == 0)
            {
                _outputHandler.NotFound($"Ocorreu um erro ao criar o anuncio, por favor tente novamente.");
                return;
            }

            var anuncioJson = JsonConvert.SerializeObject(anuncio);
            DistributedCacheEntryOptions opcoesCache = new DistributedCacheEntryOptions();
            opcoesCache.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
            _cache.SetString($"Anuncio:{anuncio.ID}", anuncioJson, opcoesCache);

            IncluirAnuncioOutput incluirAnuncioOutput = new IncluirAnuncioOutput(anuncio);
            _outputHandler.Default(incluirAnuncioOutput);
        }
    }
}

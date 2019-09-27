using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Webmotors.Application.Boundaries.ConsultarAnuncio;
using Webmotors.Application.Repositories;
using Webmotors.Domain.Anuncios;

namespace Webmotors.Application.UseCases
{
    public class ConsultarAnuncio : IUseCase
    {
        private readonly IOutput _outputHandler;
        private readonly IAnuncioRepository _anuncioRepository;
        private readonly IConfiguration _config;
        private readonly IDistributedCache _cache;

        public ConsultarAnuncio(
            IOutput outputHandler,
            IAnuncioRepository anuncioRepository,
            IConfiguration config,
            IDistributedCache cache)
        {
            _config = config;
            _cache = cache;
            _outputHandler = outputHandler;
            _anuncioRepository = anuncioRepository;
        }

        public async Task Execute(ConsultarAnuncioInput consultarAnuncioInput)
        {
            if (consultarAnuncioInput.Id == 0)
            {
                _outputHandler.NotFound($"Codigo do anuncio inválido.");
                return;
            }

            IAnuncio anuncio = null;
            string anuncioJson = _cache.GetString($"Anuncio:{consultarAnuncioInput.Id}");

            if (anuncioJson == null)
            {
                anuncio = await _anuncioRepository.Get(consultarAnuncioInput.Id);
            }

            if (anuncio == null)
            {
                _outputHandler.NotFound($"Anuncio não encontrado.");
                return;
            }

            if (anuncioJson == null)
            {
                anuncioJson = JsonConvert.SerializeObject(anuncio);
                DistributedCacheEntryOptions opcoesCache = new DistributedCacheEntryOptions();
                opcoesCache.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                _cache.SetString($"Anuncio:{anuncio.ID}", anuncioJson, opcoesCache);
            }

            ConsultarAnuncioOutput consultarAnuncioOutput = new ConsultarAnuncioOutput(anuncio);
            _outputHandler.Default(consultarAnuncioOutput);
        }
    }
}

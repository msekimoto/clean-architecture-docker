using System.Threading.Tasks;
using Webmotors.Application.Boundaries.ConsultarAnuncio;
using Webmotors.Application.Repositories;

namespace Webmotors.Application.UseCases
{
    public class ConsultarAnuncio : IUseCase
    {
        private readonly IOutput _outputHandler;
        private readonly IAnuncioRepository _anuncioRepository;

        public ConsultarAnuncio(
            IOutput outputHandler,
            IAnuncioRepository anuncioRepository)
        {
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

            var anuncio = await _anuncioRepository.Get(consultarAnuncioInput.Id);

            if (anuncio == null)
            {
                _outputHandler.NotFound($"Anuncio não encontrado.");
                return;
            }

            ConsultarAnuncioOutput consultarAnuncioOutput = new ConsultarAnuncioOutput(anuncio);
            _outputHandler.Default(consultarAnuncioOutput);
        }
    }
}

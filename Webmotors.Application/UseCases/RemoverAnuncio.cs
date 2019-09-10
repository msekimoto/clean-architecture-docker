using System.Threading.Tasks;
using Webmotors.Application.Boundaries.RemoverAnuncio;
using Webmotors.Application.Repositories;

namespace Webmotors.Application.UseCases
{
    public class RemoverAnuncio : IUseCase
    {
        private readonly IOutput _outputHandler;
        private readonly IAnuncioRepository _anuncioRepository;

        public RemoverAnuncio(
            IOutput outputHandler,
            IAnuncioRepository anuncioRepository)
        {
            _outputHandler = outputHandler;
            _anuncioRepository = anuncioRepository;
        }

        public async Task Execute(RemoverAnuncioInput removerAnuncioInput)
        {
            if (removerAnuncioInput.Id == 0)
            {
                _outputHandler.NotFound($"Codigo do anuncio inválido.");
                return;
            }

            var anuncio = await _anuncioRepository.Get(removerAnuncioInput.Id);

            if (anuncio == null)
            {
                _outputHandler.NotFound($"Anuncio não encontrado.");
                return;
            }

            await _anuncioRepository.Delete(anuncio);
            _outputHandler.Default();
        }
    }
}

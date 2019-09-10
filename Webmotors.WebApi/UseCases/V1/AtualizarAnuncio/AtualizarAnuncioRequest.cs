using System.ComponentModel.DataAnnotations;

namespace Webmotors.WebApi.UseCases.V1.AtualizarAnuncio
{
    public sealed class AtualizarAnuncioRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdMarca { get; set; }
        [Required]
        public int IdModelo { get; set; }
        [Required]
        public int IdVersao { get; set; }
        [Required]
        public int Ano { get; set; }
        [Required]
        public int Quilometragem { get; set; }
        [Required]
        public string Observacao { get; set; }
    }
}
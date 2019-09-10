namespace Webmotors.Application.Boundaries.ConsultarAnuncio
{
    public sealed class ConsultarAnuncioInput
    {
        public int Id { get; set; }

        public ConsultarAnuncioInput(int id)
        {
            Id = id;
        }
    }
}
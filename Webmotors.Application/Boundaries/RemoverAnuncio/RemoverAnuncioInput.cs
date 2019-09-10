namespace Webmotors.Application.Boundaries.RemoverAnuncio
{
    public sealed class RemoverAnuncioInput
    {
        public int Id { get; set; }

        public RemoverAnuncioInput(int id)
        {
            Id = id;
        }
    }
}
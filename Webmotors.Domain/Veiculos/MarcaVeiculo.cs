namespace Webmotors.Domain.Veiculos
{
    public class MarcaVeiculo
    {
        public int ID { get; protected set; }
        public string Name { get; protected set; }

        public MarcaVeiculo(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}

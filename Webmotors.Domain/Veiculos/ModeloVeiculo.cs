namespace Webmotors.Domain.Veiculos
{
    public class ModeloVeiculo
    {
        public int MakeID { get; protected set; }
        public int ID { get; protected set; }
        public string Name { get; protected set; }

        public ModeloVeiculo(int id, string name, int makeId)
        {
            ID = id;
            Name = name;
            MakeID = makeId;
        }
    }
}
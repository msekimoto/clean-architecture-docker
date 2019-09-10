namespace Webmotors.Domain.Veiculos
{
    public class VersaoVeiculo
    {
        public int ModelID { get; protected set; }
        public int ID { get; protected set; }
        public string Name { get; protected set; }

        public VersaoVeiculo(int id, string name, int modelId)
        {
            ID = id;
            Name = name;
            ModelID = modelId;
        }
    }
}
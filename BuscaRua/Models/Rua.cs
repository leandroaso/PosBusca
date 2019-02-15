using Microsoft.WindowsAzure.Storage.Table;

namespace BuscaRua.Models
{
    public class Rua : TableEntity
    {
        public string Nome { get; set; }
        public string CEP { get; set; }

        public Rua() { }
        public Rua(string partitionKey, string rowKey)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }
    }
}
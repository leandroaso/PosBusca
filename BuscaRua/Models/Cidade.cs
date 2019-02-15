using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuscaRua.Models
{
    public class Cidade : TableEntity
    {
        public string Nome { get; set; }
        public string Populacao { get; set; }
        public string Descricao { get; set; }

        public Cidade()
        {

        }
        public Cidade(string partitionKey, string rowKey)
        {
            PartitionKey = partitionKey;
            rowKey = partitionKey;
        }
    }
}
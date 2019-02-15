using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuscaRua.Models
{
    public class Bairro : TableEntity
    {
        public string Nome { get; set; }
        public string Regional { get; set; }
        public string IDH2000 { get; set; }
        public string Populacao2010 { get; set; }

        public Bairro() { }
        public Bairro(string partitionKey, string rowKey)
        {
            PartitionKey = partitionKey;
            PartitionKey = rowKey;
        }
    }
}
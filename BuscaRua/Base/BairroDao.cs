using BuscaRua.Models;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Linq;

namespace BuscaRua.Base
{
    public class BairroDao : BaseDao
    {
        public BairroDao() : base("Bairro") { }

        public void SaveOrUpdate(Bairro bairro)
        {
            EntityCloudTable.Execute(TableOperation.InsertOrReplace(bairro));
        }

        public List<Bairro> Listar(string partitionKey)
        {

            List<Bairro> bairros = EntityCloudTable.CreateQuery<Bairro>().Where(c => c.PartitionKey == partitionKey).ToList();

            return bairros ?? new List<Bairro>();
        }

        public List<Bairro> Listar()
        {
            List<Bairro> bairros = EntityCloudTable.CreateQuery<Bairro>().ToList();

            return bairros ?? new List<Bairro>();
        }
    }
}
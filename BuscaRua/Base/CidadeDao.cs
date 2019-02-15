using BuscaRua.Models;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Linq;

namespace BuscaRua.Base
{
    public class CidadeDao : BaseDao
    {
        public CidadeDao() : base("Cidade") { }

        public void SaveOrUpdate(Cidade cidade)
        {
            EntityCloudTable.Execute(TableOperation.InsertOrReplace(cidade));
        }

        public List<Cidade> Listar()
        {
            List<Cidade> cidades = EntityCloudTable.CreateQuery<Cidade>().Where(c => c.PartitionKey == "Ceara").ToList();

            return cidades ?? new List<Cidade>();
        }
    }
}
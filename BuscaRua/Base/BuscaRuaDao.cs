using System;
using System.Collections.Generic;
using BuscaRua.Models;
using Microsoft.WindowsAzure.Storage.Table;
using System.Linq;

namespace BuscaRua.Base
{
    public class BuscaRuaDao : BaseDao
    {
        public BuscaRuaDao() : base("Rua") { }

        public void SaveOrUpdate(Rua rua)
        {
            EntityCloudTable.Execute(TableOperation.InsertOrReplace(rua));
        }

        public List<Rua> Listar(string partitionKey)
        {
            List<Rua> ruas = EntityCloudTable.CreateQuery<Rua>().Where(c => c.PartitionKey == partitionKey).ToList();

            return ruas ?? new List<Rua>();
        }
    }
}
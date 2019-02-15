using BuscaRua.Base;
using BuscaRua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuscaRua.Controllers
{
    public class CidadeController : Controller
    {
        // GET: Cidade
        public ActionResult Index()
        {
            return View(new Cidade());
        }

        public ActionResult Novo(Cidade cidade)
        {
            cidade.PartitionKey = "Ceara";
            cidade.RowKey = Guid.NewGuid().ToString();

            new CidadeDao().SaveOrUpdate(cidade);
            return RedirectToAction("Index");
        }
        
    }
}
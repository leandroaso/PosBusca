using BuscaRua.Base;
using BuscaRua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuscaRua.Controllers
{
    public class BairroController : Controller
    {
        // GET: Bairro
        public ActionResult Index()
        {
            ViewBag.Cidades = new CidadeDao().Listar();

            return View(new Bairro());
        }

        public ActionResult Novo(Bairro bairro)
        {
            bairro.RowKey = Guid.NewGuid().ToString();

            new BairroDao().SaveOrUpdate(bairro);
            return RedirectToAction("Index");
        }

        public ActionResult Get(string partitionKey)
        {
            var bairros = new BairroDao().Listar(partitionKey);
            return Json(bairros, JsonRequestBehavior.AllowGet);
        }
    }
}
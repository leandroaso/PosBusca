using BuscaRua.Base;
using BuscaRua.Models;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace BuscaRua.Controllers
{
    public class RuaController : Controller
    {
        // GET: Rua
        public ActionResult Index()
        {
            //ViewBag.Cidades = new CidadeDao().Listar();

            ViewBag.Bairros = new BairroDao().Listar();
            var teste = JsonConvert.SerializeObject(new Bairro());
            return View(new Rua());
        }

        public ActionResult Novo(Rua rua)
        {
            rua.RowKey = Guid.NewGuid().ToString();

            new BuscaRuaDao().SaveOrUpdate(rua);
            return RedirectToAction("Index");
        }

        public ActionResult Get(string partitionKey)
        {
            var ruas = new BuscaRuaDao().Listar(partitionKey);
            return Json(ruas, JsonRequestBehavior.AllowGet);
        }
    }
}
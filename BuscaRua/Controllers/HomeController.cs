using BuscaRua.Base;
using BuscaRua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuscaRua.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Cidades = new CidadeDao().Listar();

            return View();
        }
    }
}
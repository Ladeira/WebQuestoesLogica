using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuestoesLogica.Models;

namespace WebQuestoesLogica.Controllers
{
    public class Questao3Controller : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Questão 3";

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            decimal Valor = Convert.ToDecimal(collection["Valor"]);
            decimal Acrescimo = 0.1m;

            if (Valor > 0)
            {
                Questao3Model resposta = new Questao3Model();
                resposta.Acrescimo = Valor + Valor * Acrescimo;

                return View(resposta);
            }   

            return RedirectToAction("Index");
        }
    }
}
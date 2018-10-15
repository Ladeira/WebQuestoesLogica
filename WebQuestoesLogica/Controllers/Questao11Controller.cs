using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuestoesLogica.Models;

namespace WebQuestoesLogica.Controllers
{
    public class Questao11Controller : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Questão 11";

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            decimal Valor = Convert.ToDecimal(collection["Valor"]),
                    Acrescimo = Convert.ToDecimal(collection["Acrescimo"]);

            if (Valor >= 0 && Acrescimo > 0)
            {
                Questao11Model resposta = new Questao11Model();
                resposta.Total = Valor + Acrescimo;

                return View(resposta);
            }   

            return RedirectToAction("Index");
        }
    }
}
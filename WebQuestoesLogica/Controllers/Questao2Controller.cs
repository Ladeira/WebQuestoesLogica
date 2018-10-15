using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuestoesLogica.Models;

namespace WebQuestoesLogica.Controllers
{
    public class Questao2Controller : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Questão 2";

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            decimal Valor = Convert.ToDecimal(collection["Valor"]);
            decimal Desconto = 0.1m;

            if (Valor > 0)
            {
                Questao2Model resposta = new Questao2Model();
                resposta.Desconto = Valor - Valor * Desconto;

                return View(resposta);
            }   

            return RedirectToAction("Index");
        }
    }
}
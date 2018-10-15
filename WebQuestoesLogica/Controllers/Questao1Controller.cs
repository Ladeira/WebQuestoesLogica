using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuestoesLogica.Models;

namespace WebQuestoesLogica.Controllers
{
    public class Questao1Controller : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Questão 1";

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            int Numero = Convert.ToInt32(collection["Numero"]);

            if (Numero > 20)
            {
                Questao1Model resposta = new Questao1Model();
                resposta.Numero = Numero;

                return View(resposta);
            }   

            return RedirectToAction("Index");
        }
    }
}
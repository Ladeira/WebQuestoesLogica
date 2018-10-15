
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuestoesLogica.Models;

namespace WebQuestoesLogica.Controllers
{
    public class Questao4Controller : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Questão 4";

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            int Numero1 = Convert.ToInt32(collection["Numero1"]),
                Numero2 = Convert.ToInt32(collection["Numero2"]),
                Total = Numero1 + Numero2;

            Questao4Model resposta = new Questao4Model();

            if (Total > 20)
            {   
                resposta.Total = Total + 8;

                return View(resposta);
            }
            else if (Total <= 20)
            {
                resposta.Total = Total - 5;

                return View(resposta);
            }

            return RedirectToAction("Index");
        }
    }
}
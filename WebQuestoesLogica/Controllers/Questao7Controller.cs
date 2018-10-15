
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuestoesLogica.Models;

namespace WebQuestoesLogica.Controllers
{
    public class Questao7Controller : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Questão 7";

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            ArrayList Numero = new ArrayList();

            Numero.Add(Convert.ToInt32(collection["Numero1"]));
            Numero.Add(Convert.ToInt32(collection["Numero2"]));
            Numero.Add(Convert.ToInt32(collection["Numero3"]));

            int Maior = 0;

            for (int cont = 0; cont != Numero.Count; cont++)
            {
                if (Convert.ToInt32(Numero[cont]) > Maior)
                    Maior = Convert.ToInt32(Numero[cont]);
            }

            Questao7Model resposta = new Questao7Model();

            if (Maior > 0)
            {   
                resposta.MaiorNumero = Maior;

                return View(resposta);
            }

            return RedirectToAction("Index");
        }
    }
}
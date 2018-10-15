
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuestoesLogica.Models;

namespace WebQuestoesLogica.Controllers
{
    public class Questao6Controller : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Questão 6";

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            int Idade = Convert.ToInt32(collection["Idade"]);

            Questao6Model resposta = new Questao6Model();

            if (Idade >= 18)
            {
                resposta.FaixaEtaria = "Maior de idade";

                return View(resposta);
            }
            else if (Idade < 18)
            {
                resposta.FaixaEtaria = "Menor de idade";

                return View(resposta);
            }
            else if (Idade > 65)
            {
                resposta.FaixaEtaria = "Maior de 65 anos de idade";

                return View(resposta);
            }

            return RedirectToAction("Index");
        }
    }
}
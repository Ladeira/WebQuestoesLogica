
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuestoesLogica.Models;

namespace WebQuestoesLogica.Controllers
{
    public class Questao10Controller : Controller
    {
        public static Questao10Model resposta = new Questao10Model();

        public ActionResult Index()
        {
            ViewBag.Message = "Questão 10";

            resposta.Numero1 = 1;
            resposta.Numero2 = 100;
            resposta.Multiplo = 3;

            return View(resposta);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            int Numero1 = Convert.ToInt32(collection["Numero1"]),
                Numero2 = Convert.ToInt32(collection["Numero2"]),
                Multiplo = Convert.ToInt32(collection["Multiplo"]);
            string Resultado = "";

            if (Numero1 >= 0 && Numero2 > 0 && Multiplo > 0)
            {
                for (var x = Numero1; x <= Numero2; x++)
                {
                    if (x % Multiplo == 0)
                        Resultado = Resultado + x.ToString() + ", ";
                }

                Resultado = Resultado.Substring(0, Resultado.Length - 2);

                resposta.Resultado = Resultado;

                return View(resposta);
            }

            return RedirectToAction("Index");
        }
    }
}
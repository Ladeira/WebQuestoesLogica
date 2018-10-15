
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuestoesLogica.Models;

namespace WebQuestoesLogica.Controllers
{
    public class Questao9Controller : Controller
    {
        public static ArrayList Numero = new ArrayList();

        public ActionResult Index()
        {
            ViewBag.Message = "Questão 9";

            Numero.Clear();

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            Numero.Add(Convert.ToInt32(collection["Numero"]));

            Numero.Sort();

            Questao9Model resposta = new Questao9Model();

            if (Numero.Count > 0)
            {
                string Ordem = "";

                foreach (var Item in Numero)
                {
                    Ordem = Ordem + Item + ", ";
                }

                Ordem = Ordem.Substring(0, Ordem.Length - 2);

                resposta.Ordem = Ordem;

                return View(resposta);
            }

            return RedirectToAction("Index");
        }
    }
}
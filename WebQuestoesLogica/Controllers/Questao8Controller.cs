
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuestoesLogica.Models;

namespace WebQuestoesLogica.Controllers
{
    public class Questao8Controller : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Questão 8";

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            ArrayList Numero = new ArrayList();

            Numero.Add(Convert.ToInt32(collection["Numero1"]));
            Numero.Add(Convert.ToInt32(collection["Numero2"]));
            Numero.Add(Convert.ToInt32(collection["Numero3"]));

            IComparer myComparer = new myReverserClass();

            Numero.Sort(myComparer);

            Questao8Model resposta = new Questao8Model();

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

        private class myReverserClass : IComparer
        {
            int IComparer.Compare(Object x, Object y)
            {
                return ((new CaseInsensitiveComparer()).Compare(y, x));
            }
        }
    }
}
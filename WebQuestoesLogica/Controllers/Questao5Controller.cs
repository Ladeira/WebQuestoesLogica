
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuestoesLogica.Models;

namespace WebQuestoesLogica.Controllers
{
    public class Questao5Controller : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Questão 5";

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string Uf = collection["Uf"].ToString().ToUpper();

            Questao5Model resposta = new Questao5Model();

            if (Uf == "MG")
                resposta.Gentilico = "Mineiro";

            else if (Uf == "RJ")
                resposta.Gentilico = "Carioca";

            else if (Uf == "SP")
                resposta.Gentilico = "Paulista";

            else
                resposta.Gentilico = "Outro estado";

            return View(resposta);
        }
    }
}
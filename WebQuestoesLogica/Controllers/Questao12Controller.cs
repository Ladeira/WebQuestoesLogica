
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuestoesLogica.Models;

namespace WebQuestoesLogica.Controllers
{
    public class Questao12Controller : Controller
    {
        public static ArrayList Nome = new ArrayList();
        public static Questao12Model resposta = new Questao12Model();

        public ActionResult Index()
        {
            ViewBag.Message = "Questão 12";

            resposta.Resultado = GetResultado(Nome);

            return View(resposta);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string Consulta = collection["Consulta"].ToString();

            //Questao12Model resposta = new Questao12Model();

            if (Nome.Count > 0)
            {
                resposta.Resultado = GetResultado(Nome);
                resposta.Total = Nome.Count;
                resposta.Posicao = GetPosicao(Nome, Consulta);

                if (Consulta != "")
                {
                    resposta.Posicao = 0;
                }

                return View(resposta);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            resposta.Resultado = GetResultado(Nome);

            return View(resposta);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Nome.Add(collection["Nome"].ToString());

                Questao12Model resposta = new Questao12Model();

                if (Nome.Count > 0)
                {
                    resposta.Resultado = GetResultado(Nome);

                    return View(resposta);
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        private string GetResultado(ArrayList Nome)
        {
            string Auxiliar = "";

            foreach (var Item in Nome)
            {
                Auxiliar = Auxiliar + Item + ", ";
            }

            if (Auxiliar.Length > 2)
                Auxiliar = Auxiliar.Substring(0, Auxiliar.Length - 2);
            else
                Auxiliar = "";

            return Auxiliar;
        }

        private int GetPosicao(ArrayList Nome, string Consulta)
        {
            string Caracteres = "";
            int Posicao = 0,
                ContPosicao = 0;

            foreach (var Item in Nome)
            {
                if (Consulta != "" && Posicao == 0)
                {
                    for (var x = 0; x < Consulta.Length; x++)
                    {
                        for (var y = 0; y < Item.ToString().Length; y++)
                        {
                            if (Consulta.Substring(x, 1) == Item.ToString().Substring(y, 1))
                            {
                                Caracteres = Caracteres + Item.ToString().Substring(y, 1);
                            }
                        }

                        if (Caracteres.Length == Consulta.Length)
                        {
                            Posicao = ContPosicao + 1;

                            return Posicao;
                        }
                    }
                }

                Caracteres = "";

                ContPosicao++;
            }

            return 0;
        }
    }
}
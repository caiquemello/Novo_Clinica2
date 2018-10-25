using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;

namespace MyFinance.Controllers
{
    public class ServicoController : Controller
    {
        public IActionResult Index()
        {
            ServicoModel objServico = new ServicoModel();
            ViewBag.ListaServico = objServico.ListaServico();
            return View();
        }

        [HttpPost]
        public IActionResult CriarServico(ServicoModel formulario)
        {
            if (ModelState.IsValid)
            { 
                formulario.Insert();
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public IActionResult CriarServico()
        {
            return View();
        }
    }
}
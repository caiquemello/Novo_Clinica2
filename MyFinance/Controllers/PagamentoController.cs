using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;

namespace MyFinance.Controllers
{
    public class PagamentoController : Controller
    {
        public IActionResult Index()
        {
            PagamentoModel objPagamento = new PagamentoModel();
            ViewBag.ListaPagamento = objPagamento.ListaPagamento();
            return View();
        }

        [HttpPost]
        public IActionResult CriarPagamento(PagamentoModel formulario)
        {
            if (ModelState.IsValid)
            { 
            
                formulario.Insert();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult CriarPagamento()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ExcluirConta(int id)
        {
            PagamentoModel objPagamento = new PagamentoModel();
            //objPagamento.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
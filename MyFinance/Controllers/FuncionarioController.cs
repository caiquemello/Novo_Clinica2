using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;

namespace MyFinance.Controllers
{
    public class FuncionarioController : Controller
    {
        
            public IActionResult Index()
            {
                FuncionarioModel objFuncionario = new FuncionarioModel();
                ViewBag.ListaFuncionario = objFuncionario.ListaFuncionarioModel();
                return View();
            }

        [HttpPost]
        public IActionResult CadastrarFuncionario(FuncionarioModel formulario)
        {
            if (ModelState.IsValid)
            {
                formulario.Insert();
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public IActionResult CadastrarFuncionario()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ExcluirConta(int id)
        {
            ContaModel ObjFuncionario = new ContaModel();
            ObjFuncionario.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;

namespace MyFinance.Controllers
{
    public class ClienteController : Controller
    {
      
            public IActionResult Index()
            {
                ClienteModel objClinte = new ClienteModel();
            ViewBag.ListaCliente = objClinte.ListaCliente();
            return View();
            }

        [HttpPost]
        public IActionResult CadastrarCliente(ClienteModel formulario)
        {
            if (ModelState.IsValid)
            {

                formulario.Insert();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult CadastrarCliente()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ExcluirCliente(int id)
        {
            ClienteModel objCliente = new ClienteModel();
            objCliente.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
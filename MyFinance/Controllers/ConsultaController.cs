using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;

namespace MyFinance.Controllers
{
    public class ConsultaController : Controller
    {
        public IActionResult Index()
        {
            ConsultaModel objConsulta = new ConsultaModel();
            ViewBag.ListaConsulta = objConsulta.ListaConsulta();
            return View();
        }
      
        [HttpPost]
        public IActionResult CriarConsulta(ConsultaModel formulario)
        {
            if (ModelState.IsValid)
            {

                formulario.Insert();
                return RedirectToAction("Index");
            }



            return View();
        }
        [HttpGet]
        public IActionResult CriarConsulta(int? id)
        {
            if (id != null)
            {

            }
            ClienteModel objClinte = new ClienteModel();
            ViewBag.ListaCliente = objClinte.ListaCliente();
            ConsultaModel objConsulta = new ConsultaModel();
            ViewBag.ListaConsulta = objConsulta.ListaConsulta();
            ServicoModel objServico = new ServicoModel();
            ViewBag.ListaServico = objServico.ListaServico();
            FuncionarioModel objFuncionario = new FuncionarioModel();
            ViewBag.ListaFuncionario = objFuncionario.ListaFuncionarioModel();
            PagamentoModel objPagamento = new PagamentoModel();
            ViewBag.ListaPagamento = objPagamento.ListaPagamento();

            return View();
        }
        public IActionResult CriarConsulta()
        {
            return View();

        }


        //EXTRATO//

        [HttpGet]
        [HttpPost]
        public IActionResult ExtratoConsultas(ConsultaModel formulario)
        {
            ClienteModel objClinte = new ClienteModel();
            ViewBag.ListaCliente = objClinte.ListaCliente();
            ConsultaModel objConsulta = new ConsultaModel();
            ViewBag.ListaConsulta = objConsulta.ListaConsulta();
            ServicoModel objServico = new ServicoModel();
            ViewBag.ListaServico = objServico.ListaServico();
            FuncionarioModel objFuncionario = new FuncionarioModel();
            ViewBag.ListaFuncionario = objFuncionario.ListaFuncionarioModel();
            PagamentoModel objPagamento = new PagamentoModel();
            ViewBag.ListaPagamento = objPagamento.ListaPagamento();
            return View();
        }

    }
}
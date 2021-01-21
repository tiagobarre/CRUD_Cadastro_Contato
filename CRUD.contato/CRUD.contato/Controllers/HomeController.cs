
using CRUD.contato.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.contato.Controllers
{
    public class HomeController : Controller
    {
       
        public async Task<IActionResult> Index(ContatoModel obj, int? id)
        {
            ViewBag.ListarContatos = await Task.Run(() => obj.ListarContatos(id));

            if(obj.mensagem == "Salvo")
            {
                return await Task.Run(() => RedirectToAction("Index", "Home"));

            }
         
            return View();
        }
        public async Task<IActionResult> Deletar(ContatoModel obj, int? id)
        {
            ViewBag.ListarContatos = await Task.Run(() => obj.ListarContatos(id));

            if (obj.mensagem != null)
            {
                return await Task.Run(() => RedirectToAction("Index", "Home"));
            }

            return View();
        }

    }
}

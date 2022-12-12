using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bcquant.Models;
using Newtonsoft.Json;
using bcquant.ModelView;
using bcquant.Domain.Interfaces;

namespace bcquant.Controllers
{
    public class HomeController : Controller
    {
        //private readonly bcquant_localContext _context;

        private IUnidadeConstrutivaRepository _repositoryUnidadeConstrutiva;

        public HomeController(IUnidadeConstrutivaRepository repositoryUnidadeConstrutiva)
        {
           this._repositoryUnidadeConstrutiva = repositoryUnidadeConstrutiva;

        }

        public IActionResult Index()
        {

            UnidadeConstrutivaModelView model = new UnidadeConstrutivaModelView();

            model.unidadeConstrutivas = _repositoryUnidadeConstrutiva.ListarTodos();
          

            return View(); 
        }
        

        [HttpPost]
        public IActionResult About(UnidadeConstrutivaModelView model)
        {
         
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

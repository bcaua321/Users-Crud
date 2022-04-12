using Microsoft.AspNetCore.Mvc;
using CriandoProjeto.Models;
using System.Linq;

namespace CriandoProjeto.Controllers 
{
    public class HomeController : Controller 
    {
        public IActionResult Index()
        {
            return View();
        } 

        public IActionResult Usuarios()
        {
            return View(Usuario.Listagem);
        } 
        
        [HttpGet]
        public IActionResult Cadastrar(int? id)
        {
            Usuario user = new Usuario();
            if(id.HasValue && Usuario.Listagem.Any(u => u.Id == id))
            {
               user = Usuario.Listagem.Single(u => u.Id == id);
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario user)
        {
            Usuario.Salvar(user);
            return RedirectToAction("Usuarios");
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            Usuario user = new Usuario();
            if(id.HasValue && Usuario.Listagem.Any(u => u.Id == id))
            {
               user = Usuario.Listagem.Single(u => u.Id == id);
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Excluir(Usuario user)
        {
            TempData["Excluiu"] = Usuario.Excluir(user.Id);
            return RedirectToAction("Usuarios");
        }

    }
}
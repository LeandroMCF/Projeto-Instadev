using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Instadev.Models;

namespace Projeto_Instadev.Controllers
{
    [Route("Publicacao")]
    public class PublicacaoController : Controller
    {
        Publicacao publi = new Publicacao();

        public IActionResult Index()
        {
            return View();
        }
    }
}
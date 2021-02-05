using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Projeto_Instadev.Models;
using System;

namespace Projeto_Instadev.Controllers
{
    [Route("PaginaPerfil")]
    public class PaginaPerfilController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.IO;
using Projeto_Instadev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Projeto_Instadev.Controllers
{
    [Route("PaginaPerfil")]
    public class PaginaPerfilController : Controller
    {
        Publicacao publi = new Publicacao();
        Usuario user = new Usuario();

        public IActionResult Index()
        {
            ViewBag.Publicacao = new Publicacao();
            ViewBag.Usuario = new Usuario();
            ViewBag.Comentarios = new Comentario();
            ViewBag.Name = HttpContext.Session.GetString("_Name");
            ViewBag.IdUser = HttpContext.Session.GetString("_UserId");        
            ViewBag.UserName = HttpContext.Session.GetString("_UserName");
            return View();
        }
    }
}
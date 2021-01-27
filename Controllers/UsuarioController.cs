using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Instadev.Models;

namespace Projeto_Instadev.Controllers
{
    [Route("Usuario")]
    public class UsuarioController : Controller
    {
        Usuario usuarioModel = new Usuario();
        
        public IActionResult Index()
        {
            
            ViewBag.Usuarios = usuarioModel.ReadAll();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Usuario novoUsuario     = new Usuario();

            novoUsuario.IdUsuario   = Int32.Parse(form["IdUsuario"]);
            novoUsuario.Nome        = form["Nome"];
            novoUsuario.Foto        = form["Foto"];
            novoUsuario.DataNascimento = form["DataNascimento"];
            novoUsuario.Email       = form["Email"];
            novoUsuario.UserName    = form["UserName"];
            novoUsuario.Senha       = form["Senha"];

            usuarioModel.Create(novoUsuario);            
            ViewBag.Usuarios = usuarioModel.ReadAll();

            return LocalRedirect("~/Usuario");
        }

    }
}
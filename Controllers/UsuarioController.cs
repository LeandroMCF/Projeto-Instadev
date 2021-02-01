using System;
using System.IO;
using Projeto_Instadev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Projeto_Instadev.Controllers
{
    [Route("Usuario")]
    public class UsuarioController : Controller
    {
        Usuario usuarioModel = new Usuario();
        

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Usuarios = usuarioModel.ReadAll();
            return View();
        }


        public int GerarId()
        {
            Random numAleatorio = new Random();

            int id = numAleatorio.Next(100, 999);

            usuarioModel.GerarIdUsuario(id);
            
            while (usuarioModel.GerarIdUsuario(id))
            {
                id = numAleatorio.Next(100, 999);
                usuarioModel.GerarIdUsuario(id);
            }
            return id;
        }
        

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Usuario novoUsuario     = new Usuario();

            novoUsuario.IdUsuario   = GerarId();
            novoUsuario.Nome        = form["Nome"];
            novoUsuario.Foto        = form["Foto"];
            novoUsuario.DataNascimento = form["DataNascimento"];
            novoUsuario.Email       = form["Email"];
            novoUsuario.UserName    = form["UserName"];
            novoUsuario.Senha       = form["Senha"];

            usuarioModel.Create(novoUsuario);            
            ViewBag.Usuarios = usuarioModel.ReadAll();

            return LocalRedirect("~/Usuario/Listar");
        }
    }
}
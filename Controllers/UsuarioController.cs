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
        

        public IActionResult Index()
        {
            ViewBag.Usuarios = usuarioModel.ReadAll();
            return View();
        }


        [Route("GerarId")]
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
            if(form.Files.Count > 0)
            {
                // Upload Início
                var file    = form.Files[0];
                var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/usuario");

                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }
                
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                novoUsuario.Foto  = file.FileName;                
            }
            else
            {
                novoUsuario.Foto = "padrao.png";
            }
            novoUsuario.DataNascimento = form["DataNascimento"];
            novoUsuario.Email       = form["Email"];
            novoUsuario.UserName    = form["UserName"];
            novoUsuario.Senha       = form["Senha"];

            usuarioModel.Create(novoUsuario);            
            ViewBag.Usuarios = usuarioModel.ReadAll();

            return LocalRedirect("~/Login");
        }
    }
}
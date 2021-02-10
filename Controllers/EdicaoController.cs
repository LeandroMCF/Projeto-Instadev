using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Instadev.Models;

namespace Projeto_Instadev.Controllers
{
    
    
    [Route("Edicao")]
    public class EdicaoController: Controller
    {
        Usuario usuarioModel = new Usuario();
        Comentario comentario = new Comentario();
        Publicacao publicacao = new Publicacao();

        public IActionResult Index()

        {
            ViewBag.Usuario = new Usuario();
            ViewBag.IdUser = HttpContext.Session.GetString("_UserId");
            ViewBag.UserName = HttpContext.Session.GetString("_UserName");
            return View();
        }









        [Route("EditarNome")]
        public IActionResult EditarNome(IFormCollection form)
        {
            //Novo usuário para alteração
            Usuario User = new Usuario();
            
            User.Foto = HttpContext.Session.GetString("_Foto");
            User.Nome = form["Nome"];
            User.UserName = HttpContext.Session.GetString("_UserName");
            User.Email = HttpContext.Session.GetString("_Email");
            User.Senha = HttpContext.Session.GetString("_Senha");
            User.IdUsuario = int.Parse(HttpContext.Session.GetString("_UserId"));

            if (User.Nome == null)
                {
                    User.Nome = HttpContext.Session.GetString("_Name");
                }         

            int id = int.Parse(HttpContext.Session.GetString("_UserId"));
                
            usuarioModel.Update(User, id);
                

            return LocalRedirect("~/PaginaPerfil");
        }





        [Route("EditarUserName")]
        public IActionResult EditarUserName(IFormCollection form)
        {
            //Novo usuário para alteração
            Usuario User = new Usuario();
            
            User.Foto = HttpContext.Session.GetString("_Foto");
            User.Nome = HttpContext.Session.GetString("_Name");
            User.UserName = form["UserName"];
            User.Email = HttpContext.Session.GetString("_Email");
            User.Senha = HttpContext.Session.GetString("_Senha");
            User.IdUsuario = int.Parse(HttpContext.Session.GetString("_UserId"));

            if (User.UserName == null)
                {
                    User.UserName = HttpContext.Session.GetString("_UserName");
                }         

            int id = int.Parse(HttpContext.Session.GetString("_UserId"));
                
            usuarioModel.Update(User, id);
                

            return LocalRedirect("~/PaginaPerfil");
        }






        [Route("EditarEmail")]
        public IActionResult EditarEmail(IFormCollection form)
        {
            //Novo usuário para alteração
            Usuario User = new Usuario();
            
            User.Foto = HttpContext.Session.GetString("_Foto");
            User.Nome = HttpContext.Session.GetString("_Name");
            User.UserName = HttpContext.Session.GetString("_UserName");
            User.Email = form["Email"];
            User.Senha = HttpContext.Session.GetString("_Senha");
            User.IdUsuario = int.Parse(HttpContext.Session.GetString("_UserId"));

            if (User.Email == null)
                {
                    User.Email = HttpContext.Session.GetString("_Email");
                }         

            int id = int.Parse(HttpContext.Session.GetString("_UserId"));
                
            usuarioModel.Update(User, id);
                

            return LocalRedirect("~/Edicao");
        }







        [Route("EditarFoto")]
        public IActionResult EditarFoto(IFormCollection form)
        {
            //Novo usuário para alteração
            Usuario User = new Usuario();
            
            User.Foto = form["Foto"];
            if(form.Files.Count > 0)
            {
                // Upload Início
                var file    = form.Files[0];
                var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/publicacao");

                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }
                
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                User.Foto  = file.FileName;                
            }
            else
            {
                User.Foto = "padrao.png";
            }

            User.Nome = HttpContext.Session.GetString("_Name");
            User.UserName = HttpContext.Session.GetString("_UserName");
            User.Email = HttpContext.Session.GetString("_Email");
            User.Senha = HttpContext.Session.GetString("_Senha");
            User.IdUsuario = int.Parse(HttpContext.Session.GetString("_UserId"));

            if (User.Email == null)
                {
                    User.Email = HttpContext.Session.GetString("_Email");
                }         

            int id = int.Parse(HttpContext.Session.GetString("_UserId"));
                
            usuarioModel.Update(User, id);
                

            return LocalRedirect("~/Edicao");
        }





        [Route("Deletar")]
        public IActionResult EditarDeletar(int id)
        {
                id = int.Parse(HttpContext.Session.GetString("_UserId"));
                usuarioModel.Delete(id);
                publicacao.Deletepubli(id);
                comentario.DeleteComent(id);

                return LocalRedirect("~/"); //Qual página?
        }

    }
}
    

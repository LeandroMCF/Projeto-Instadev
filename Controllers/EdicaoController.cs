using System.Collections.Generic;
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
            ViewBag.UserName = HttpContext.Session.GetString("_UserName");
            return View();
        }

            
        [Route("Editar")]
        public IActionResult EditarNome(IFormCollection form)
        {
            //Novo usuário para alteração
            Usuario User = new Usuario();
            
            User.Foto = form["Foto"];
            User.Nome = form["Nome"];
            User.UserName = form["UserName"];
            User.Email = form["Email"];
            User.Senha = form["Senha"];
            User.IdUsuario = int.Parse(HttpContext.Session.GetString("_UserId"));


            if (User.Nome == null)
                {
                    User.Nome = HttpContext.Session.GetString("_Name");
                }
            if (User.Foto == null)
                {
                    User.Foto = "padrao.png";
                }
            if (User.Email == null)
                {
                    User.Email = HttpContext.Session.GetString("_Email");
                }
            if (User.UserName == null)
                {
                    User.UserName = HttpContext.Session.GetString("_UserName");
                }
            if (User.Senha == null)
                {
                    User.Senha = HttpContext.Session.GetString("_Senha");
                }
                

            int id = int.Parse(HttpContext.Session.GetString("_UserId"));
                
            usuarioModel.Update(User, id);
                

            return LocalRedirect("~/PaginaPerfil");
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
    

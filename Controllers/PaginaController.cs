using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Instadev.Models;
using System;

namespace Projeto_Instadev.Controllers
{
    public class EditController
    {
        [Route("Edicao")]
        public class EdicaoController: Controller
        {
            Usuario usuarioModel = new Usuario();

            public IActionResult Index()

            {
                ViewBag.UserName = HttpContext.Session.GetString("_UserName");
                return View();
            }

            
            [Route("Alterar")]
            public IActionResult Editar(IFormCollection form)
            {
                //Novo usuário para alteração
                Usuario User = new Usuario();
                
                User.Nome        = form["Nome"];
                if (User.Nome == null)
                    {
                        User.Nome = HttpContext.Session.GetString("_Name");
                    }
                User.Foto        = form["Foto"];
                    
                
                User.Email       = form["Email"];
                if (User.Email == null)
                    {
                        User.Email = HttpContext.Session.GetString("_Email");
                    }

                User.UserName    = form["UserName"];
                if (User.UserName == null)
                    {
                        User.UserName = HttpContext.Session.GetString("_UserName");
                    }

                User.IdUsuario   = int.Parse(HttpContext.Session.GetString("_UserId"));
                
                int id = int.Parse(HttpContext.Session.GetString("_UserId"));
                
                usuarioModel.Update(User, id);
                

                return Redirect("~/Perfil");
            }
            
            [Route("Deletar")]

            public IActionResult EditarDeletar(int id)
            {
                Usuario User     = new Usuario();
                User.IdUsuario   = int.Parse(HttpContext.Session.GetString("_UserId"));
                User.Delete(id);
                return Redirect("~/Login"); //Qual página?
            }

            }
        }
    }

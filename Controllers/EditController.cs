using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Instadev.Models;

namespace Projeto_Instadev.Controllers
{
    public class EditController
    {
        [Route("Edicao")]
        public class EdicaoController: Controller
        {
            Usuario usuarioAntigo = new Usuario();
            Usuario usuarioEditado = new Usuario();
            public IActionResult Index()

            {
                ViewBag.UserName = HttpContext.Session.GetString("_UserName");
                return View();
            }

            
            [Route("Alterar")]
            public IActionResult Editar(IFormCollection form)
            {
                //Novo usuário para alteração

                usuarioEditado.Nome        = form["Nome"];
                usuarioEditado.Foto        = form["Foto"];
                usuarioEditado.Email       = form["Email"];
                usuarioEditado.UserName    = form["UserName"];
                

                if(usuarioEditado.Nome != usuarioAntigo.Nome)
                {
                    usuarioEditado.Update(usuarioAntigo);
                }else if(usuarioEditado.Email != usuarioAntigo.Email)
                {
                    usuarioEditado.Update(usuarioAntigo);
                }else if(usuarioEditado.UserName != usuarioAntigo.UserName)
                {
                    usuarioEditado.Update(usuarioAntigo);
                }
                return LocalRedirect("~/");
                }
            
            [Route("Deletar")]

            public IActionResult EditarDeletar(int id)
            {
                usuarioEditado.Delete(id);
                return LocalRedirect("~/"); //Qual página?
            }

            }
        }
    }

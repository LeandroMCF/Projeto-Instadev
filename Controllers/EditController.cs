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
            Usuario usuarioModel = new Usuario();

            public IActionResult Index()
            {
                return View();
            }

            
            [Route("Alterar")]
            public IActionResult Editar(IFormCollection form)
            {
                //Novo usuário para alteração
                Usuario usuarioAntigo  = new Usuario();
                Usuario usuarioEditado = new Usuario();

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
                return LocalRedirect("~/Usuario/EditPerfil");
                }
            }
            
        }
    }

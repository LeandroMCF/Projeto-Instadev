using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Instadev.Models;
using System;


namespace Projeto_Instadev.Controllers
{

    [Route("Login")]

    public class LoginController: Controller
    {
        [TempData]
        public string Mensagem { get; set; }
        Usuario usuarioModel = new Usuario();

        public IActionResult Index()
    {
        return View();
    }
        

       [Route("Logar")]

         public IActionResult Logar(IFormCollection form)
        {
             
            Usuario usuarioModel = new Usuario();
            
            List<string> csv = usuarioModel.ReadAllLinesCSV(usuarioModel.PATH);

            var logado = 
            csv.Find(
                x => 
                x.Split(";")[4] == form["Email"] && 
                x.Split(";")[6] == form["Senha"]
            );
            
                    
            if(logado != null)
            {
                 HttpContext.Session.SetString("_UserName", logado.Split(";")[1]);
                 HttpContext.Session.SetString("_UserId", logado.Split(";")[0]);
                 return LocalRedirect("~/Publicacao");

            }else{
           
             Mensagem = "Senha ou username incorreto !";
            
             return LocalRedirect("~/Login");
            }

        }
      
            [Route("Logout")]
            public IActionResult Logout()
            {
                 HttpContext.Session.Remove("_UserName");
                 return LocalRedirect("~/Login");
            }
    }
}

    

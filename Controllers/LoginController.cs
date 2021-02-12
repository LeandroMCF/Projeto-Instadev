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
        ViewBag.Login = new LoginController();
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
                x.Split(";")[4] == form["Email"] || x.Split(";")[5] == form["Email"] && 
                x.Split(";")[6] == form["Senha"]
            );
            
                    
            if(logado != null)
            {
                HttpContext.Session.SetString("_UserId", logado.Split(";")[0]);
                HttpContext.Session.SetString("_Name", logado.Split(";")[1]);
                HttpContext.Session.SetString("_Foto", logado.Split(";")[2]);
                HttpContext.Session.SetString("_Email", logado.Split(";")[4]);
                HttpContext.Session.SetString("_UserName", logado.Split(";")[5]);
                HttpContext.Session.SetString("_Senha", logado.Split(";")[6]);
                return LocalRedirect("~/Publicacao");

            }else{
           
                Mensagem = "Senha ou Email/UserName incorreto !";
            
                return LocalRedirect("~/Login");
            }
        }
      
            [Route("Logout")]
            public IActionResult Logout()
            {
                HttpContext.Session.Remove("_UserName");
                HttpContext.Session.Remove("_UserId");
                HttpContext.Session.Remove("_Name");
                HttpContext.Session.Remove("_Email");
                return LocalRedirect("~/Login");
            }
    }
}

    

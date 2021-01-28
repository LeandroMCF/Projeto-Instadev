

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Projeto_Instadev.Controllers
{
    [Route("Login")]
    public class LoginController: Controller
    {
        
        [TempData]
         public string Mensagem { get; set; }

        public IActionResult Logar(IFormCollection form)
        {
            Usuario usuarioModel = new Usuario();
            // Lemos todos os arquivos do CSV

            List<string> csv = usuarioModel.ReadAllLinesCSV("Database/Usuario.csv");

            // Verificamos se as informações passadas existe na lista de string
            var logado = 
            csv.Find(
                x => 
                x.Split(";")[2] == form["Email"] && 
                x.Split(";")[3] == form["Senha"]
            );

            
            if(logado != null)
            {
                return LocalRedirect("~/");
            }else{

            Mensagem = "Dados incorretos, tente novamente...";
            
            return LocalRedirect("~/Login");
            }

        }
    }
}

    

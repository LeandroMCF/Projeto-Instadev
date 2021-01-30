using System;
using System.IO;
using Projeto_Instadev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Projeto_Instadev.Controllers
{
    [Route("Publicacao")]
    public class PublicacaoController : Controller
    {
        Publicacao publi = new Publicacao();

        [Route("Listar")]

        public IActionResult Index()
        {
            ViewBag.Publicacao = publi.ReadAll();
            return View();
        }

        public int GerarId()
        {
            Random numAleatorio = new Random();
            int id = numAleatorio.Next(100, 999);
            publi.GerarIdPostagem(id);
            while (publi.GerarIdPostagem(id))
            {
                id = numAleatorio.Next(100, 999);
                publi.GerarIdPostagem(id);
            }
            return id;
        }


        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Publicacao publicacao = new Publicacao();
            publicacao.IdPublicacao = GerarId();
            publicacao.Legenda = form["descricao"];
            if (form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Publicacao");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                publicacao.Imagem = file.FileName;
            }
            else
            {
                publicacao.Imagem = "padrão.png";
            }

            publi.CriarPublicacao(publicacao);
            ViewBag.Publicacao = publi.ReadAll();

            return LocalRedirect("~/Equipe");
        }
    }
}

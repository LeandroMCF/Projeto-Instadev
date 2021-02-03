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
        Comentario comentario = new Comentario();  

        
        public IActionResult Index()
        {
            ViewBag.Publicacao = publi.ReadAll();
            ViewBag.Comentarios = new Comentario();
            ViewBag.IdLogado = HttpContext.Session.GetString("_UserId");
            return View();
        }
        [Route("GerarId")]
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


        [Route("Publicar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Publicacao publicacao = new Publicacao();
            publicacao.IdPublicacao = GerarId();
            publicacao.IdUser = int.Parse(HttpContext.Session.GetString("_UserId"));
            publicacao.Legenda = form["descricao"];
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
                publicacao.Imagem  = file.FileName;                
            }
            publi.CriarPublicacao(publicacao);
            ViewBag.Publicacao = publi.ReadAll();

            return LocalRedirect("~/Publicacao");
        }

        [Route("Publicacao/{id}")]

        public IActionResult Excluir(int id)
        {
            publi.ExcluirPublicacao(id);
            comentario.ExcluirComentPubli(id);
            ViewBag.Publicacao = publi.ReadAll();
            ViewBag.Comentario = new Comentario();
            
            return LocalRedirect("~/Publicacao");
        }

        [Route("Comentar")]
        public IActionResult Comentar(IFormCollection form)
        {
            Publicacao publicacao = new Publicacao();
            Comentario coment = new Comentario();

            coment.IdComentario = GerarId();
            coment.IdPublicacao = int.Parse(form["id_publicacao"]);
            coment.IdUser = int.Parse(HttpContext.Session.GetString("_UserId"));
            coment.Mensagem = form["comentar"];
            comentario.CriarComentario(coment);

            return Redirect("~/Publicacao");
        }
    }
}

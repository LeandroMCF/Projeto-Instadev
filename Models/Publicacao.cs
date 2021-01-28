using System.Collections.Generic;
using System.IO;

namespace Projeto_Instadev.Models
{
    public class Publicacao : InstaDevBase
    {
        public int IdPublicacao { get; set; }
        
        public string Imagem { get; set; }
        
        public string Legenda { get; set; }
        
        public int Likes { get; set; }

        public string PATH = "Database/publicacao.csv";

        private string PrepararLinha(Publicacao p)
        {
            return $"{p.IdPublicacao};{p.Imagem};{p.Legenda};{p.Likes}";
        }

        public void CriarPublicacao(string _path)
        {
            Publicacao publicacao = new Publicacao();
            Usuario usuario = new Usuario();
            string[] linha = { PrepararLinha(publicacao) };
            File.AppendAllLines(_path, linha);
        }

        public List<Publicacao> ListarPublicacao(string _path)
        {
            List<Publicacao> publicacao = new List<Publicacao>();
            string[] linhas = File.ReadAllLines(_path);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Publicacao publi = new Publicacao();
                publi.IdPublicacao = int.Parse(linha[1]);
                publi.Imagem = linha [2];
                publi.Legenda = linha [3];
                publi.Likes = int.Parse(linha [4]);
                publicacao.Add(publi);
            }
            return publicacao;
        }
    }
}
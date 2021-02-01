using System;
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

        public const string PATH = "Database/publicacao.csv";

        private string PrepararLinha(Publicacao p)
        {
            return $"{p.IdPublicacao};{p.Legenda};{p.Imagem}";
        }

        public Publicacao()
        {
            CreateFolderAndFile(PATH);
        }

        public void CriarPublicacao(Publicacao p)
        {
            string[] linha = { PrepararLinha(p) };
            File.AppendAllLines(PATH, linha);
        }

        public List<Publicacao> ReadAll()
        {
            List<Publicacao> publicacao = new List<Publicacao>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Publicacao publi = new Publicacao();
                publi.IdPublicacao = int.Parse(linha[0]);
                publi.Legenda = linha [1];
                publi.Imagem = linha [2];
                publicacao.Add(publi);
            }
            return publicacao;
        }

        public void Editarpublicacao(Publicacao p)
        {
            List<string> linhas = new List<string>();
            linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == p.IdPublicacao.ToString());
            linhas.Add( PrepararLinha(p) );
            RewriteCSV(PATH, linhas);
        }

        public void ExcluirPublicacao(Publicacao p)
        {
            List<string> linhas = new List<string>();
            linhas.RemoveAll(x => x.Split(";")[0] == p.IdPublicacao.ToString());
        }
        public bool GerarIdPostagem(int id)
        {
            bool existe = false;
            List<string> csv = new List<string>();
            csv = ReadAllLinesCSV(PATH);
            foreach (var item in csv)
            {
                string[] linha = item.Split(";");
                if (id == int.Parse(linha[0]))
                {
                    existe = true;
                }
                else
                {
                    existe = false;
                }
            }
            return existe;
        }
    }
}
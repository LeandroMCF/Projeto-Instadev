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

        public int IdUser { get; set; }
        
        

        public const string PATH = "Database/publicacao.csv";

        private string PrepararLinha(Publicacao p)
        {
            return $"{p.IdPublicacao};{p.IdUser};{p.Legenda};{p.Imagem}";
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
                publi.IdUser = int.Parse(linha[1]);
                publi.Legenda = linha [2];
                publi.Imagem = linha [3];
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

        public void ExcluirPublicacao(int id)
        {
            List<string> linhas = new List<string>();
            linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            RewriteCSV(PATH, linhas);
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

        public List<Publicacao> BuscarIdUser(int id_user)
        {
            List<Publicacao> publicacaos = ReadAll().FindAll(x => x.IdUser == id_user);
            return publicacaos;
        }
         public void Deletepubli(int idUsuario)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            // 1;FLA;fla.png
            linhas.RemoveAll(x => x.Split(";")[1] == idUsuario.ToString());                        
            RewriteCSV(PATH, linhas);
        }
    }
}
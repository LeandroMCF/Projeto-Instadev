using System.Collections.Generic;
using System.IO;


namespace Projeto_Instadev.Models
{
    public class Comentario : InstaDevBase
    {
        public int IdComentario { get; set; }
        
        public string Mensagem { get; set; }

        public int IdPublicacao { get; set; }
        
        
        
        private const string PATH = "Database/Comentarios.csv";

        public Comentario()
        {
            CreateFolderAndFile(PATH);
        }

        public string PrepararLinha(Comentario c)
        {
            return $"{c.IdComentario};{c.IdPublicacao};{c.Mensagem}";
        }

        public void CriarComentario(Comentario c)
        {
            string[] linha = { PrepararLinha(c) };
            File.AppendAllLines(PATH, linha);
        }

        public List<Comentario> ReadAll()
        {
            List<Comentario> comentarios = new List<Comentario>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Comentario coment = new Comentario();
                Publicacao publicacao = new Publicacao();
                coment.IdComentario = int.Parse(linha[0]);
                coment.IdPublicacao = int.Parse(linha[1]);
                coment.Mensagem = linha[2];
                comentarios.Add(coment);
            }
            return comentarios;
        }

        public void EditarComentario(Comentario c, Publicacao p)
        {
            List<string> linhas = new List<string>();
            linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == c.IdComentario.ToString());
            linhas.Add( PrepararLinha(c) );
            RewriteCSV(PATH, linhas);
        }
        public void ExcluirComentario(int id)
        {
            List<string> linhas = new List<string>();
            linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            RewriteCSV(PATH, linhas);
        }
        public bool GerarIdComentario(int id)
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
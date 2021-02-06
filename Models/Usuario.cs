using System;
using System.Collections.Generic;
using System.IO;
using Projeto_Instadev.Interfaces;

namespace Projeto_Instadev.Models
{
    public class Usuario : InstaDevBase , IUsuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string DataNascimento { get; set; }        
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Senha { get; set; }

        public string PATH = "Database/Usuario.csv";


        //Método para preparar a linha para a estrutura do objeto Usuário,retornando um arquivo csv
        private string PrepararLinha(Usuario u)
        {
            return $"{u.IdUsuario};{u.Nome};{u.Foto};{u.DataNascimento};{u.Email};{u.UserName};{u.Senha}";
        }


        public Usuario()
        {
            CreateFolderAndFile(PATH);
        }

        //Método para criar um usuário
        public void Create(Usuario u)
        {
            string[] linha = { PrepararLinha(u) };
            File.AppendAllLines(PATH, linha);
        }

        //Método para ler os usuários
        public List<Usuario> ReadAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Usuario usuario = new Usuario();
                
                usuario.IdUsuario = int.Parse(linha[0]);
                usuario.Nome = linha[1];
                usuario.Foto = linha[2];
                usuario.DataNascimento = linha[3];
                usuario.Email = linha[4];
                usuario.UserName = linha[5];
                usuario.Senha = linha[6];

                usuarios.Add(usuario);
            }
            return usuarios;
        }

        //Método para alterar um usuário
        public void Update(Usuario p, int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            linhas.Add( PrepararLinha(p) );                        
            RewriteCSV(PATH, linhas); 
        }

        //Método para deletar um usuário
        public void Delete(int idUsuario)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            // 1;FLA;fla.png
            linhas.RemoveAll(x => x.Split(";")[0] == idUsuario.ToString());                        
            RewriteCSV(PATH, linhas);
        }

        public bool GerarIdUsuario(int id)
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
        public List<Usuario> BuscarNome(int id_user)
        {
            List<Usuario> usersId = ReadAll().FindAll(x => x.IdUsuario == id_user);
            return usersId;
        }
    }
}
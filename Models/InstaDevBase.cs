using System;
using System.Collections.Generic;
using System.IO;

namespace Projeto_Instadev.Models
{
    public class InstaDevBase 
    {
        //metodo para criar pasta e arquivo
        public void CreateFolderAndFile(string _path){
            //Database/Equipe.csv
            string folder = _path.Split("/")[0];//o folder (Pasta) será = Database

        //caso não exista um diretório (pasta),então: 
        if(!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);//criar um diretório (pasta)
        }
        //caso não exista um arquivo (_path), então :
        if(!File.Exists(_path))
        {
            File.Create(_path);//criar um arquivo (_path)
        }

        }
        
        //método para ler as linhas do arquivo
        public List<string> ReadAllLinesCSV(string path){

            List<string> linhas = new List<string>(); 
            
            //using -> responsável por abrir e fechar o arquivo automaticamente
            //StreamReader -> ler dados de um arquivo
            using(StreamReader file = new StreamReader(path))
            {
                string linha;

                //percorrer as linhas com um laço while
                while((linha = file.ReadLine()) !=null)
                {
                    linhas.Add(linha);
                }
            }

            return linhas;
        }

        //método para reescrever as linhas do arquivo
        public void RewriteCSV(string path,List<string> linhas){

            //StreamWriter -> Escrever os dados em um arquivo
            using(StreamWriter output = new StreamWriter(path))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }

        //metodo para gerrrar ID

    }
}
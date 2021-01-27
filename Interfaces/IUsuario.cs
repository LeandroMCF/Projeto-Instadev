using System.Collections.Generic;
using Projeto_Instadev.Models;

namespace Projeto_Instadev.Interfaces
{
    public interface IUsuario
    {
         //Criar
        void Create(Usuario u);
        //Ler
        List<Usuario> ReadAll();
        //Alterar
        void Update(Usuario u);
        //Excluir
        void Delete(int id); 
    }
}
using System.Collections.Generic;

namespace Projeto_Instadev.Models
{
    public class Feed : Publicacao
    {
        Publicacao publi = new Publicacao();
        
        public dynamic ReadAll()
        {
            return Ler(publi.PATH);
        }
    }
}
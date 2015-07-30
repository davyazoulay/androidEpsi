using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportFounderLibrary
{
    public class Ville
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string CP { get; set; }

        public Ville() { }

        public Ville(int idVille)
        {
            Id = idVille;
        }

        public Ville(int id, string nom, string cp)
        {
            Id = id;
            Nom = nom;
            CP = cp;
        }
    }
}

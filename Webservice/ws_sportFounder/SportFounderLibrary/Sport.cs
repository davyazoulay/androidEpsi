using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportFounderLibrary
{
    public class Sport
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Type { get; set; }

        public Sport() { }

        public Sport(int idSport)
        {
            Id = idSport;
        }

        public Sport(int id, string nom, string type)
        {
            Id = id;
            Nom = nom;
            Type = type;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportFounderLibrary
{
    public class Groupe
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }

        public Groupe() { }

        public Groupe(int idGroupe)
        {
            Id = idGroupe;
        }

        public Groupe(int id, string nom, string libelle, string description)
        {
            Id = id;
            Nom = nom;
            Libelle = libelle;
            Description = description;
        }
    }
}

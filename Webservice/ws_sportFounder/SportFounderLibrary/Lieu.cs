using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportFounderLibrary
{
    public class Lieu
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public string CP { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public Lieu() { }

        public Lieu(int idLieu)
        {
            Id = idLieu;
        }

        public Lieu(int id, string nom, string libelle, string description, string cp, string latitude, string longitude)
        {
            Id = id;
            Nom = nom;
            Libelle = libelle;
            Description = description;
            CP = cp;
            Latitude = latitude;
            Longitude = longitude;
        }

        public Lieu(string nom, string libelle, string description, string cp, string latitude, string longitude)
        {
            Nom = nom;
            Libelle = libelle;
            Description = description;
            CP = cp;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}

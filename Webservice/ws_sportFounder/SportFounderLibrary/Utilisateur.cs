using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportFounderLibrary
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Mdp { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Pays { get; set; }
        public string Ville { get; set; }
        public string CP { get; set; }
        public int Type { get; set; }

        public Utilisateur() { }

        public Utilisateur(int idUser)
        {
            Id = idUser;
        }

        public Utilisateur(string login, string mdp)
        {
            Login = login;
            Mdp = mdp;
        }

        public Utilisateur(int id, string login, string mdp, string nom, string prenom, string email, DateTime date_naissance, string pays, string ville, string code_postal, int type)
        {
            Id = id;
            Login = login;
            Mdp = mdp;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            DateNaissance = date_naissance;
            Pays = pays;
            Ville = ville;
            CP = code_postal;
            Type = type;
        }

        // ami récupéré : on récup pas son motdepasse et login
        public Utilisateur(int id, string nom, string prenom, string email, DateTime date_naissance, string pays, string ville, string code_postal)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            DateNaissance = date_naissance;
            Pays = pays;
            Ville = ville;
            CP = code_postal;
        }

        public Utilisateur(string login, string mdp, string nom, string prenom, string email, DateTime date_naissance, string pays, string ville, string code_postal, int type)
        {
            Login = login;
            Mdp = mdp;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            DateNaissance = date_naissance;
            Pays = pays;
            Ville = ville;
            CP = code_postal;
            Type = type;
        }
    }
}

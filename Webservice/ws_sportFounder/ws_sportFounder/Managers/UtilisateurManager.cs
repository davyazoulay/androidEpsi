using SportFounderLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ws_sportFounder.Models;

namespace ws_sportFounder.Managers
{
    public class UtilisateurManager
    {
        public UtilisateurManager() { }

        public Utilisateur getUserById(int idUser)
        {
            Utilisateur UtilisateurRecherche = null;
            if (idUser > 0)
            {
                UtilisateurDAO UtilisateurDao = new UtilisateurDAO();
                return UtilisateurDao.getUserById(idUser);
            }
            return UtilisateurRecherche;
        }

        public List<Utilisateur> getListAmis(int idUser)
        {
            List<Utilisateur> listAmis = new List<Utilisateur>();
            if (idUser > 0)
            {
                UtilisateurDAO UtilisateurDao = new UtilisateurDAO();
                return UtilisateurDao.getListAmis(idUser);
            }
            return listAmis;
        }

        public List<Groupe> getListGroupes(int idUser)
        {
            List<Groupe> listGroupes = new List<Groupe>();
            if (idUser > 0)
            {
                UtilisateurDAO userDao = new UtilisateurDAO();
                return userDao.getListGroupes(idUser);
            }
            return listGroupes;
        }

        public List<Sport> getMesSports(int idUser)
        {
            List<Sport> listSports = null;
            if (idUser > 0)
            {
                SportDAO SportDao = new SportDAO();
                return SportDao.getMesSports(idUser);
            }
            return listSports;
        }

        public int createUser(Utilisateur newUser)
        {
            int idNewUser = 0;
            if (newUser != null)
            {
                UtilisateurDAO UtilisateurDao = new UtilisateurDAO();
                idNewUser = UtilisateurDao.createUser(newUser);
            }
            return idNewUser;
        }


        public bool updateUser(Utilisateur userToUpdate)
        {
            bool isUpdated = false;
            if (userToUpdate != null)
            {
                UtilisateurDAO UtilisateurDAO = new UtilisateurDAO();
                isUpdated = UtilisateurDAO.updateUser(userToUpdate);
            }
            return isUpdated;
        }

        public Utilisateur connexionUser(Utilisateur userToConnect)
        {
            if (userToConnect != null)
            {
                UtilisateurDAO utilisateurDAO = new UtilisateurDAO();
                Utilisateur utilisateur = utilisateurDAO.getUserByLogin(userToConnect.Login);
                if (utilisateur != null && utilisateur.Mdp == userToConnect.Mdp)
                {
                    return utilisateur;
                }
                return userToConnect;
            }
            return userToConnect;
            // On retourne l'utilisateur complet si la connexion est réussie, sinon on renvoie l'utilisateur casi vide
        }

        public void addSport(int idUser, int idSport)
        {
            UtilisateurDAO userDAO = new UtilisateurDAO();
            userDAO.addSport(idUser, idSport);
        }

        public void addFriend(int idUser, int idFriend)
        {
            UtilisateurDAO userDAO = new UtilisateurDAO();
            userDAO.addFriend(idUser, idFriend);
        }

        public bool exists(int iduser)
        {
            bool exists = false;
            if (iduser > 0)
            {
                UtilisateurDAO userDAO = new UtilisateurDAO();
                exists = userDAO.exists(iduser);
            }
            return exists;
        }

        public bool loginExists(string login)
        {
            bool exists = false;
            UtilisateurDAO userDAO = new UtilisateurDAO();
            Utilisateur user = userDAO.getUserByLogin(login);
            if (user != null)
                exists = true;
            return exists;
        }
    }
}
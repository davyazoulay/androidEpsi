using SportFounderLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ws_sportFounder.Models;

namespace ws_sportFounder.Managers
{
    public class GroupeManager
    {
        public GroupeManager() { }

        public Groupe getGroupeById(int idGroupe)
        {
            Groupe GroupeRecherche = null;
            if (idGroupe > 0)
            {
                GroupeDAO GroupeDao = new GroupeDAO();
                return GroupeDao.getGroupeById(idGroupe);
            }
            return GroupeRecherche;
        }

        public List<Utilisateur> getListUsers(int idGroupe)
        {
            List<Utilisateur> listUsers = new List<Utilisateur>();
            if (idGroupe > 0)
            {
                GroupeDAO GroupeDao = new GroupeDAO();
                return GroupeDao.getListUsers(idGroupe);
            }
            return listUsers;
        }

        public int createGroupe(Groupe newGroupe)
        {
            int idNewGroupe = 0;
            if (newGroupe != null)
            {
                GroupeDAO GroupeDao = new GroupeDAO();
                idNewGroupe = GroupeDao.createGroupe(newGroupe);
            }
            return idNewGroupe;
        }


        //public bool updateGroupe(Groupe GroupeToUpdate)
        //{
        //    bool isUpdated = false;
        //    if (GroupeToUpdate != null)
        //    {
        //        GroupeDAO GroupeDAO = new GroupeDAO();
        //        isUpdated = GroupeDAO.updateGroupe(GroupeToUpdate);
        //    }
        //    return isUpdated;
        //}

        

        public bool exists(int idGroupe)
        {
            bool exists = false;
            if (idGroupe > 0)
            {
                GroupeDAO GroupeDAO = new GroupeDAO();
                exists = GroupeDAO.exists(idGroupe);
            }
            return exists;
        }
    }
}
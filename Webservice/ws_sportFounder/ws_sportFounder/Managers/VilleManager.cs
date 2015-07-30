using SportFounderLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ws_sportFounder.Models;

namespace ws_sportFounder.Managers
{
    public class VilleManager
    {
        public VilleManager() { }

        public Ville getVilleById(int idVille)
        {
            Ville VilleRecherche = null;
            if (idVille > 0)
            {
                VilleDAO VilleDao = new VilleDAO();
                return VilleDao.getVilleById(idVille);
            }
            return VilleRecherche;
        }

        public int createVille(Ville newVille)
        {
            int idNewVille = 0;
            if (newVille != null)
            {
                VilleDAO VilleDao = new VilleDAO();
                idNewVille = VilleDao.createVille(newVille);
            }
            return idNewVille;
        }


        //public bool updateVille(Ville villeToUpdate)
        //{
        //    bool isUpdated = false;
        //    if (villeToUpdate != null)
        //    {
        //        VilleDAO VilleDAO = new VilleDAO();
        //        isUpdated = VilleDAO.updateVille(villeToUpdate);
        //    }
        //    return isUpdated;
        //}

        

        public bool exists(int idville)
        {
            bool exists = false;
            if (idville > 0)
            {
                VilleDAO villeDAO = new VilleDAO();
                exists = villeDAO.exists(idville);
            }
            return exists;
        }
    }
}
using SportFounderLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ws_sportFounder.Models;

namespace ws_sportFounder.Managers
{
    public class SportManager
    {
        public SportManager() { }

        public Sport getSportById(int idSport)
        {
            Sport SportRecherche = null;
            if (idSport > 0)
            {
                SportDAO SportDao = new SportDAO();
                return SportDao.getSportById(idSport);
            }
            return SportRecherche;
        }

        public int createSport(Sport newSport)
        {
            int idNewSport = 0;
            if (newSport != null)
            {
                SportDAO SportDao = new SportDAO();
                idNewSport = SportDao.createSport(newSport);
            }
            return idNewSport;
        }

        public List<Lieu> getLieux(int idSport)
        {
            List<Lieu> listSports = new List<Lieu>();
            if (idSport > 0)
            {
                LieuDAO LieuDao = new LieuDAO();
                return LieuDao.getLieuxBySport(idSport);
            }
            return listSports;
        }


        //public bool updateSport(Sport villeToUpdate)
        //{
        //    bool isUpdated = false;
        //    if (villeToUpdate != null)
        //    {
        //        SportDAO SportDAO = new SportDAO();
        //        isUpdated = SportDAO.updateSport(villeToUpdate);
        //    }
        //    return isUpdated;
        //}

        

        public bool exists(int idville)
        {
            bool exists = false;
            if (idville > 0)
            {
                SportDAO villeDAO = new SportDAO();
                exists = villeDAO.exists(idville);
            }
            return exists;
        }
    }
}
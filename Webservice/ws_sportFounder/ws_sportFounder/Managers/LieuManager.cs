using SportFounderLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ws_sportFounder.Models;

namespace ws_sportFounder.Managers
{
    public class LieuManager
    {
        public LieuManager() { }

        public Lieu getLieuById(int idLieu)
        {
            Lieu LieuRecherche = null;
            if (idLieu > 0)
            {
                LieuDAO LieuDao = new LieuDAO();
                return LieuDao.getLieuById(idLieu);
            }
            return LieuRecherche;
        }

        public List<Lieu> getAllLieux()
        {
            LieuDAO LieuDao = new LieuDAO();
            List<Lieu> listLieux = LieuDao.getAllLieux();
            return listLieux;
        }

        public List<Sport> getSports(int idLieu)
        {
            List<Sport> listSports = new List<Sport>();
            if (idLieu > 0)
            {
                SportDAO SportDao = new SportDAO();
                return SportDao.getSportsByLieu(idLieu);    
            }
            return listSports;
        }

        public int createLieu(Lieu newLieu)
        {
            int idNewLieu = 0;
            if (newLieu != null)
            {
                LieuDAO LieuDao = new LieuDAO();
                idNewLieu = LieuDao.createLieu(newLieu);
            }
            return idNewLieu;
        }


        //public bool updateLieu(Lieu villeToUpdate)
        //{
        //    bool isUpdated = false;
        //    if (villeToUpdate != null)
        //    {
        //        LieuDAO LieuDAO = new LieuDAO();
        //        isUpdated = LieuDAO.updateLieu(villeToUpdate);
        //    }
        //    return isUpdated;
        //}

        

        public bool exists(int idville)
        {
            bool exists = false;
            if (idville > 0)
            {
                LieuDAO villeDAO = new LieuDAO();
                exists = villeDAO.exists(idville);
            }
            return exists;
        }
    }
}
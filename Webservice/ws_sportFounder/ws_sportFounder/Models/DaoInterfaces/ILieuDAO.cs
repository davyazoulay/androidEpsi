using SportFounderLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ws_sportFounder.Models.DaoInterfaces
{
    interface ILieuDAO
    {
        Lieu getLieuById(int idLieu);
        int createLieu(Lieu newLieu);
        //bool updateLieu(Lieu updatedLieu);
        bool exists(int idLieu);
        List<Lieu> getAllLieux();
        List<Lieu> getLieuxBySport(int idSport);
    }
}

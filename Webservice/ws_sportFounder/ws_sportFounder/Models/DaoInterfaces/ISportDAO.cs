using SportFounderLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ws_sportFounder.Models.DaoInterfaces
{
    interface ISportDAO
    {
        Sport getSportById(int idSport);
        int createSport(Sport newSport);
        //bool updateSport(Sport updatedSport);
        bool exists(int idSport);
        List<Sport> getMesSports(int idUser);
        List<Sport> getSportsByLieu(int idLieu);
    }
}

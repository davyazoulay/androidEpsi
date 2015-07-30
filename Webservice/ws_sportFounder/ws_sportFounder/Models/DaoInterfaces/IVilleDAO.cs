using SportFounderLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ws_sportFounder.Models.DaoInterfaces
{
    interface IVilleDAO
    {
        Ville getVilleById(int idVille);
        int createVille(Ville newVille);
        //bool updateVille(Ville updatedVille);
        bool exists(int idVille);
    }
}

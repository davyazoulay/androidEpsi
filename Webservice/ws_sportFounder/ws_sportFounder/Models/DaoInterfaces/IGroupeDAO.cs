using SportFounderLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ws_sportFounder.Models.DaoInterfaces
{
    interface IGroupeDAO
    {
        Groupe getGroupeById(int idGroupe);
        int createGroupe(Groupe newGroupe);
        List<Utilisateur> getListUsers(int idGroupe);
        //bool updateGroupe(Groupe updatedGroupe);
        bool exists(int idGroupe);
    }
}

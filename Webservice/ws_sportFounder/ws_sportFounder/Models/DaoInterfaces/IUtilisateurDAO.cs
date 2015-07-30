using SportFounderLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ws_sportFounder.Models.DaoInterfaces
{
    interface IUtilisateurDAO
    {
        Utilisateur getUserById(int idUser);
        Utilisateur getUserByLogin(string login);
        int createUser(Utilisateur newUser);
        bool updateUser(Utilisateur updatedUser);
        bool exists(int idUser);
        List<Utilisateur> getListAmis(int idUser);
        List<Groupe> getListGroupes(int idUser);
        void addSport(int idUser, int idSport);
        void addFriend(int idUser, int idFriend);
    }
}

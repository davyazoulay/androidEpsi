using SportFounderLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ws_sportFounder.Managers;

namespace ws_sportFounder.Controllers.RestControllers
{
    public class UtilisateurController : ApiController
    {
        LibraryManager Librairie = new LibraryManager();

        [HttpGet]
        [Route("api/Utilisateur/GetUserById/{idUserRecherche}")]
        public IHttpActionResult GetUserById([FromUri]int idUserRecherche)
        {
            if (idUserRecherche > 0)
            {
                try
                {
                    if (Librairie.Utilisateurs.exists(idUserRecherche))
                    {
                        Utilisateur UserRecherche = Librairie.Utilisateurs.getUserById(idUserRecherche);
                        Console.WriteLine(UserRecherche.DateNaissance);
                        Console.WriteLine(UserRecherche.DateNaissance.Date);
                        return Ok(UserRecherche);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception e)
                {
                    return InternalServerError(e);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/Utilisateur/CheckIfLoginExists/{login}")]
        public IHttpActionResult CheckIfLoginExists([FromUri]string login)
        {
            try
            {
                if (Librairie.Utilisateurs.loginExists(login))
                {
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("api/Utilisateur/GetListAmis/{idUser}")]
        public IHttpActionResult GetListAmis([FromUri]int idUser)
        {
            if (idUser > 0)
            {
                try
                {
                    if (Librairie.Utilisateurs.exists(idUser))
                    {
                        List<Utilisateur> listAmis = Librairie.Utilisateurs.getListAmis(idUser);
                        return Ok(listAmis);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception e)
                {
                    return InternalServerError(e);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/Utilisateur/GetListGroupes/{idUser}")]
        public IHttpActionResult GetListGroupes([FromUri]int idUser)
        {
            if (idUser > 0)
            {
                try
                {
                    if (Librairie.Utilisateurs.exists(idUser))
                    {
                        List<Groupe> listGroupes = Librairie.Utilisateurs.getListGroupes(idUser);
                        return Ok(listGroupes);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception e)
                {
                    return InternalServerError(e);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/Utilisateur/AddSport/{idUser}/{idSport}")]
        public IHttpActionResult AddSport([FromUri]int idUser, [FromUri]int idSport)
        {
            if (idUser > 0 && idSport > 0)
            {
                try
                {
                    if (Librairie.Utilisateurs.exists(idUser) && Librairie.Sports.exists(idSport))
                    {
                        Librairie.Utilisateurs.addSport(idUser, idSport);
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception e)
                {
                    return InternalServerError(e);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/Utilisateur/AddFriend/{idUser}/{idFriend}")]
        public IHttpActionResult AddFriend([FromUri]int idUser, [FromUri]int idFriend)
        {
            if (idUser > 0 && idFriend > 0)
            {
                try
                {
                    if (Librairie.Utilisateurs.exists(idUser) && Librairie.Utilisateurs.exists(idFriend))
                    {
                        Librairie.Utilisateurs.addFriend(idUser, idFriend);
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception e)
                {
                    return InternalServerError(e);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/Utilisateur/GetMesSports/{idUser}")]
        public IHttpActionResult GetMesSports([FromUri]int idUser)
        {
            if (idUser > 0)
            {
                try
                {
                    if (Librairie.Utilisateurs.exists(idUser))
                    {
                        List<Sport> listSports = Librairie.Utilisateurs.getMesSports(idUser);
                        return Ok(listSports);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception e)
                {
                    return InternalServerError(e);
                }
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("api/Utilisateur/Connexion")]
        public IHttpActionResult Connexion([FromBody]Utilisateur userToConnect)
        {
            if (!string.IsNullOrWhiteSpace(userToConnect.Login)
                && !string.IsNullOrWhiteSpace(userToConnect.Mdp))
            {
                try
                {
                    Utilisateur user = Librairie.Utilisateurs.connexionUser(userToConnect);
                    return Ok(user);
                }
                catch (Exception e)
                {
                    return InternalServerError(e);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("api/Utilisateur/CreateUser")]
        public IHttpActionResult CreateUser([FromBody]Utilisateur newUser)
        {
            if (!string.IsNullOrWhiteSpace(newUser.Login)
                && !string.IsNullOrWhiteSpace(newUser.Mdp)
                && !string.IsNullOrWhiteSpace(newUser.Nom)
                && !string.IsNullOrWhiteSpace(newUser.Prenom)
                && !string.IsNullOrWhiteSpace(newUser.Email)
                && !string.IsNullOrWhiteSpace(newUser.Pays)
                && !string.IsNullOrWhiteSpace(newUser.Ville)
                && !string.IsNullOrWhiteSpace(newUser.CP))
            {
                try
                {
                    int idNewUser = Librairie.Utilisateurs.createUser(newUser);
                    Utilisateur UserCreatedIdOnly = new Utilisateur(idNewUser);
                    return Ok(UserCreatedIdOnly);
                }
                catch (Exception e)
                {
                    return InternalServerError(e);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("api/Utilisateur/UpdateUser")]
        public IHttpActionResult UpdateUser([FromBody]Utilisateur userModified)
        {
            if (userModified.Id > 0
                && !string.IsNullOrWhiteSpace(userModified.Login)
                && !string.IsNullOrWhiteSpace(userModified.Mdp)
                && !string.IsNullOrWhiteSpace(userModified.Nom)
                && !string.IsNullOrWhiteSpace(userModified.Prenom)
                && !string.IsNullOrWhiteSpace(userModified.Email)
                && !string.IsNullOrWhiteSpace(userModified.Pays)
                && !string.IsNullOrWhiteSpace(userModified.Ville)
                && !string.IsNullOrWhiteSpace(userModified.CP))
            {
                try
                {
                    if (Librairie.Utilisateurs.exists(userModified.Id))
                    {
                        bool isModified = Librairie.Utilisateurs.updateUser(userModified);
                        return Ok(userModified);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception e)
                {
                    return InternalServerError(e);
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
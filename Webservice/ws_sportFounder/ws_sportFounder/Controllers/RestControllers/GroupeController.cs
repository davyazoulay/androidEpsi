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
    public class GroupeController : ApiController
    {
        LibraryManager Librairie = new LibraryManager();

        [HttpGet]
        [Route("api/Groupe/GetGroupeById/{idGroupeRecherche}")]
        public IHttpActionResult GetGroupeById([FromUri]int idGroupeRecherche)
        {
            if (idGroupeRecherche > 0)
            {
                try
                {
                    if (Librairie.Groupes.exists(idGroupeRecherche))
                    {
                        Groupe GroupeRecherche = Librairie.Groupes.getGroupeById(idGroupeRecherche);
                        return Ok(GroupeRecherche);
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
        [Route("api/Groupe/CreateGroupe")]
        public IHttpActionResult CreateGroupe([FromBody]Groupe newGroupe)
        {
            if (!string.IsNullOrWhiteSpace(newGroupe.Nom)
                && !string.IsNullOrWhiteSpace(newGroupe.Libelle)
                && !string.IsNullOrWhiteSpace(newGroupe.Description))
            {
                try
                {
                    int idNewGroupe = Librairie.Groupes.createGroupe(newGroupe);
                    Groupe GroupeCreatedIdOnly = new Groupe(idNewGroupe);
                    return Ok(GroupeCreatedIdOnly);
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
        [Route("api/Groupe/GetListUsers/{idGroupe}")]
        public IHttpActionResult GetListUsers([FromUri]int idGroupe)
        {
            if (idGroupe > 0)
            {
                try
                {
                    if (Librairie.Groupes.exists(idGroupe))
                    {
                        List<Utilisateur> listUsers = Librairie.Groupes.getListUsers(idGroupe);
                        return Ok(listUsers);
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

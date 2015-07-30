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
    public class SportController : ApiController
    {
        LibraryManager Librairie = new LibraryManager();

        [HttpGet]
        [Route("api/Sport/GetSportById/{idSportRecherche}")]
        public IHttpActionResult GetSportById([FromUri]int idSportRecherche)
        {
            if (idSportRecherche > 0)
            {
                try
                {
                    if (Librairie.Sports.exists(idSportRecherche))
                    {
                        Sport SportRecherche = Librairie.Sports.getSportById(idSportRecherche);
                        return Ok(SportRecherche);
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
        [Route("api/Sport/GetLieux/{idSport}")]
        public IHttpActionResult GetLieux([FromUri]int idSport)
        {
            if (idSport > 0)
            {
                try
                {
                    if (Librairie.Sports.exists(idSport))
                    {
                        List<Lieu> listLieux = Librairie.Sports.getLieux(idSport);
                        return Ok(listLieux);
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
        [Route("api/Sport/CreateSport")]
        public IHttpActionResult CreateSport([FromBody]Sport newSport)
        {
            if (!string.IsNullOrWhiteSpace(newSport.Nom)
                && !string.IsNullOrWhiteSpace(newSport.Type))
            {
                try
                {
                    int idNewSport = Librairie.Sports.createSport(newSport);
                    Sport SportCreatedIdOnly = new Sport(idNewSport);
                    return Ok(SportCreatedIdOnly);
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

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
    public class VilleController : ApiController
    {
        LibraryManager Librairie = new LibraryManager();

        [HttpGet]
        [Route("api/Ville/GetVilleById/{idVilleRecherche}")]
        public IHttpActionResult GetVilleById([FromUri]int idVilleRecherche)
        {
            if (idVilleRecherche > 0)
            {
                try
                {
                    if (Librairie.Villes.exists(idVilleRecherche))
                    {
                        Ville VilleRecherche = Librairie.Villes.getVilleById(idVilleRecherche);
                        return Ok(VilleRecherche);
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
        [Route("api/Ville/CreateVille")]
        public IHttpActionResult CreateVille([FromBody]Ville newVille)
        {
            if (!string.IsNullOrWhiteSpace(newVille.Nom)
                && !string.IsNullOrWhiteSpace(newVille.CP))
            {
                try
                {
                    int idNewVille = Librairie.Villes.createVille(newVille);
                    Ville VilleCreatedIdOnly = new Ville(idNewVille);
                    return Ok(VilleCreatedIdOnly);
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

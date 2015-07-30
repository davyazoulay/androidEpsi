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
    public class LieuController : ApiController
    {
        LibraryManager Librairie = new LibraryManager();

        [HttpGet]
        [Route("api/Lieu/GetLieuById/{idLieuRecherche}")]
        public IHttpActionResult GetLieuById([FromUri]int idLieuRecherche)
        {
            if (idLieuRecherche > 0)
            {
                try
                {
                    if (Librairie.Lieus.exists(idLieuRecherche))
                    {
                        Lieu LieuRecherche = Librairie.Lieus.getLieuById(idLieuRecherche);
                        return Ok(LieuRecherche);
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
        [Route("api/Lieu/GetAllLieux")]
        public IHttpActionResult GetAllLieux()
        {
            try
            {
                List<Lieu> listLieux = Librairie.Lieus.getAllLieux();
                return Ok(listLieux);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("api/Lieu/GetSports/{idLieu}")]
        public IHttpActionResult GetSports([FromUri]int idLieu)
        {
            if (idLieu > 0)
            {
                try
                {
                    if (Librairie.Lieus.exists(idLieu))
                    {
                        List<Sport> listSports = Librairie.Lieus.getSports(idLieu);
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
        [Route("api/Lieu/CreateLieu")]
        public IHttpActionResult CreateLieu([FromBody]Lieu newLieu)
        {
            if (!string.IsNullOrWhiteSpace(newLieu.Nom)
                && !string.IsNullOrWhiteSpace(newLieu.CP))
            {
                try
                {
                    int idNewLieu = Librairie.Lieus.createLieu(newLieu);
                    Lieu LieuCreatedIdOnly = new Lieu(idNewLieu);
                    return Ok(LieuCreatedIdOnly);
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

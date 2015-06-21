using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using applicationAndroid.Models;

namespace applicationAndroid.Controllers
{
    public class AssoNoteLieuxController : ApiController
    {
        private appli_androidContext db = new appli_androidContext();

        // GET api/AssoNoteLieux
        public IQueryable<ASSO_NOTE_LIEU> GetASSO_NOTE_LIEU()
        {
            return db.ASSO_NOTE_LIEU;
        }

        // GET api/AssoNoteLieux/5
        [ResponseType(typeof(ASSO_NOTE_LIEU))]
        public IHttpActionResult GetASSO_NOTE_LIEU(int id)
        {
            ASSO_NOTE_LIEU asso_note_lieu = db.ASSO_NOTE_LIEU.Find(id);
            if (asso_note_lieu == null)
            {
                return NotFound();
            }

            return Ok(asso_note_lieu);
        }

        // PUT api/AssoNoteLieux/5
        public IHttpActionResult PutASSO_NOTE_LIEU(int id, ASSO_NOTE_LIEU asso_note_lieu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asso_note_lieu.id_utilisateur)
            {
                return BadRequest();
            }

            db.Entry(asso_note_lieu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ASSO_NOTE_LIEUExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/AssoNoteLieux
        [ResponseType(typeof(ASSO_NOTE_LIEU))]
        public IHttpActionResult PostASSO_NOTE_LIEU(ASSO_NOTE_LIEU asso_note_lieu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ASSO_NOTE_LIEU.Add(asso_note_lieu);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ASSO_NOTE_LIEUExists(asso_note_lieu.id_utilisateur))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = asso_note_lieu.id_utilisateur }, asso_note_lieu);
        }

        // DELETE api/AssoNoteLieux/5
        [ResponseType(typeof(ASSO_NOTE_LIEU))]
        public IHttpActionResult DeleteASSO_NOTE_LIEU(int id)
        {
            ASSO_NOTE_LIEU asso_note_lieu = db.ASSO_NOTE_LIEU.Find(id);
            if (asso_note_lieu == null)
            {
                return NotFound();
            }

            db.ASSO_NOTE_LIEU.Remove(asso_note_lieu);
            db.SaveChanges();

            return Ok(asso_note_lieu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ASSO_NOTE_LIEUExists(int id)
        {
            return db.ASSO_NOTE_LIEU.Count(e => e.id_utilisateur == id) > 0;
        }
    }
}
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
    public class GroupeController : ApiController
    {
        private appli_androidContext db = new appli_androidContext();

        // GET api/Groupe
        public IQueryable<GROUPE> GetGROUPEs()
        {
            return db.GROUPEs;
        }

        // GET api/Groupe/5
        [ResponseType(typeof(GROUPE))]
        public IHttpActionResult GetGROUPE(int id)
        {
            GROUPE groupe = db.GROUPEs.Find(id);
            if (groupe == null)
            {
                return NotFound();
            }

            return Ok(groupe);
        }

        // PUT api/Groupe/5
        public IHttpActionResult PutGROUPE(int id, GROUPE groupe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupe.id)
            {
                return BadRequest();
            }

            db.Entry(groupe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GROUPEExists(id))
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

        // POST api/Groupe
        [ResponseType(typeof(GROUPE))]
        public IHttpActionResult PostGROUPE(GROUPE groupe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GROUPEs.Add(groupe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = groupe.id }, groupe);
        }

        // DELETE api/Groupe/5
        [ResponseType(typeof(GROUPE))]
        public IHttpActionResult DeleteGROUPE(int id)
        {
            GROUPE groupe = db.GROUPEs.Find(id);
            if (groupe == null)
            {
                return NotFound();
            }

            db.GROUPEs.Remove(groupe);
            db.SaveChanges();

            return Ok(groupe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GROUPEExists(int id)
        {
            return db.GROUPEs.Count(e => e.id == id) > 0;
        }
    }
}
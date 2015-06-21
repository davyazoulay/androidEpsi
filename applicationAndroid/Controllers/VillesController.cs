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
    public class VillesController : ApiController
    {
        private appli_androidContext db = new appli_androidContext();

        // GET api/Villes
        public IQueryable<VILLE> GetVILLEs()
        {
            return db.VILLEs;
        }

        // GET api/Villes/5
        [ResponseType(typeof(VILLE))]
        public IHttpActionResult GetVILLE(int id)
        {
            VILLE ville = db.VILLEs.Find(id);
            if (ville == null)
            {
                return NotFound();
            }

            return Ok(ville);
        }

        // PUT api/Villes/5
        public IHttpActionResult PutVILLE(int id, VILLE ville)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ville.id)
            {
                return BadRequest();
            }

            db.Entry(ville).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VILLEExists(id))
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

        // POST api/Villes
        [ResponseType(typeof(VILLE))]
        public IHttpActionResult PostVILLE(VILLE ville)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VILLEs.Add(ville);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ville.id }, ville);
        }

        // DELETE api/Villes/5
        [ResponseType(typeof(VILLE))]
        public IHttpActionResult DeleteVILLE(int id)
        {
            VILLE ville = db.VILLEs.Find(id);
            if (ville == null)
            {
                return NotFound();
            }

            db.VILLEs.Remove(ville);
            db.SaveChanges();

            return Ok(ville);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VILLEExists(int id)
        {
            return db.VILLEs.Count(e => e.id == id) > 0;
        }
    }
}
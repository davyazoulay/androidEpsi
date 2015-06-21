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
    public class LieuxController : ApiController
    {
        private appli_androidContext db = new appli_androidContext();

        // GET api/Lieux
        public IQueryable<LIEU> GetLIEUx()
        {
            return db.LIEUx;
        }

        // GET api/Lieux/5
        [ResponseType(typeof(LIEU))]
        public IHttpActionResult GetLIEU(int id)
        {
            LIEU lieu = db.LIEUx.Find(id);
            if (lieu == null)
            {
                return NotFound();
            }

            return Ok(lieu);
        }

        // PUT api/Lieux/5
        public IHttpActionResult PutLIEU(int id, LIEU lieu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lieu.id)
            {
                return BadRequest();
            }

            db.Entry(lieu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LIEUExists(id))
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

        // POST api/Lieux
        [ResponseType(typeof(LIEU))]
        public IHttpActionResult PostLIEU(LIEU lieu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LIEUx.Add(lieu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lieu.id }, lieu);
        }

        // DELETE api/Lieux/5
        [ResponseType(typeof(LIEU))]
        public IHttpActionResult DeleteLIEU(int id)
        {
            LIEU lieu = db.LIEUx.Find(id);
            if (lieu == null)
            {
                return NotFound();
            }

            db.LIEUx.Remove(lieu);
            db.SaveChanges();

            return Ok(lieu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LIEUExists(int id)
        {
            return db.LIEUx.Count(e => e.id == id) > 0;
        }
    }
}
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
    public class PublicationController : ApiController
    {
        private appli_androidContext db = new appli_androidContext();

        // GET api/Publication
        public IQueryable<PUBLICATION> GetPUBLICATIONs()
        {
            return db.PUBLICATIONs;
        }

        // GET api/Publication/5
        [ResponseType(typeof(PUBLICATION))]
        public IHttpActionResult GetPUBLICATION(int id)
        {
            PUBLICATION publication = db.PUBLICATIONs.Find(id);
            if (publication == null)
            {
                return NotFound();
            }

            return Ok(publication);
        }

        // PUT api/Publication/5
        public IHttpActionResult PutPUBLICATION(int id, PUBLICATION publication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != publication.id)
            {
                return BadRequest();
            }

            db.Entry(publication).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PUBLICATIONExists(id))
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

        // POST api/Publication
        [ResponseType(typeof(PUBLICATION))]
        public IHttpActionResult PostPUBLICATION(PUBLICATION publication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PUBLICATIONs.Add(publication);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = publication.id }, publication);
        }

        // DELETE api/Publication/5
        [ResponseType(typeof(PUBLICATION))]
        public IHttpActionResult DeletePUBLICATION(int id)
        {
            PUBLICATION publication = db.PUBLICATIONs.Find(id);
            if (publication == null)
            {
                return NotFound();
            }

            db.PUBLICATIONs.Remove(publication);
            db.SaveChanges();

            return Ok(publication);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PUBLICATIONExists(int id)
        {
            return db.PUBLICATIONs.Count(e => e.id == id) > 0;
        }
    }
}
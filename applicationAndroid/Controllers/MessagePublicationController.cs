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
    public class MessagePublicationController : ApiController
    {
        private appli_androidContext db = new appli_androidContext();

        // GET api/MessagePublication
        public IQueryable<MESSAGE_PUBLICATION> GetMESSAGE_PUBLICATION()
        {
            return db.MESSAGE_PUBLICATION;
        }

        // GET api/MessagePublication/5
        [ResponseType(typeof(MESSAGE_PUBLICATION))]
        public IHttpActionResult GetMESSAGE_PUBLICATION(int id)
        {
            MESSAGE_PUBLICATION message_publication = db.MESSAGE_PUBLICATION.Find(id);
            if (message_publication == null)
            {
                return NotFound();
            }

            return Ok(message_publication);
        }

        // PUT api/MessagePublication/5
        public IHttpActionResult PutMESSAGE_PUBLICATION(int id, MESSAGE_PUBLICATION message_publication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != message_publication.id_publication)
            {
                return BadRequest();
            }

            db.Entry(message_publication).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MESSAGE_PUBLICATIONExists(id))
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

        // POST api/MessagePublication
        [ResponseType(typeof(MESSAGE_PUBLICATION))]
        public IHttpActionResult PostMESSAGE_PUBLICATION(MESSAGE_PUBLICATION message_publication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MESSAGE_PUBLICATION.Add(message_publication);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MESSAGE_PUBLICATIONExists(message_publication.id_publication))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = message_publication.id_publication }, message_publication);
        }

        // DELETE api/MessagePublication/5
        [ResponseType(typeof(MESSAGE_PUBLICATION))]
        public IHttpActionResult DeleteMESSAGE_PUBLICATION(int id)
        {
            MESSAGE_PUBLICATION message_publication = db.MESSAGE_PUBLICATION.Find(id);
            if (message_publication == null)
            {
                return NotFound();
            }

            db.MESSAGE_PUBLICATION.Remove(message_publication);
            db.SaveChanges();

            return Ok(message_publication);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MESSAGE_PUBLICATIONExists(int id)
        {
            return db.MESSAGE_PUBLICATION.Count(e => e.id_publication == id) > 0;
        }
    }
}
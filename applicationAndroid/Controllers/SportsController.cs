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
    public class SportsController : ApiController
    {
        private appli_androidContext db = new appli_androidContext();

        // GET api/Sports
        public IQueryable<SPORT> GetSPORTs()
        {
            return db.SPORTs;
        }

        // GET api/Sports/5
        [ResponseType(typeof(SPORT))]
        public IHttpActionResult GetSPORT(int id)
        {
            SPORT sport = db.SPORTs.Find(id);
            if (sport == null)
            {
                return NotFound();
            }

            return Ok(sport);
        }

        // PUT api/Sports/5
        public IHttpActionResult PutSPORT(int id, SPORT sport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sport.id)
            {
                return BadRequest();
            }

            db.Entry(sport).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SPORTExists(id))
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

        // POST api/Sports
        [ResponseType(typeof(SPORT))]
        public IHttpActionResult PostSPORT(SPORT sport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SPORTs.Add(sport);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sport.id }, sport);
        }

        // DELETE api/Sports/5
        [ResponseType(typeof(SPORT))]
        public IHttpActionResult DeleteSPORT(int id)
        {
            SPORT sport = db.SPORTs.Find(id);
            if (sport == null)
            {
                return NotFound();
            }

            db.SPORTs.Remove(sport);
            db.SaveChanges();

            return Ok(sport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SPORTExists(int id)
        {
            return db.SPORTs.Count(e => e.id == id) > 0;
        }
    }
}
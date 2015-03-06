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
    public class UtilisateurController : ApiController
    {
        private appli_androidContext db = new appli_androidContext();

        // GET api/Utilisateur
        public IQueryable<UTILISATEUR> GetUTILISATEURs()
        {
            return db.UTILISATEURs;
        }

        // GET api/Utilisateur/5
        [ResponseType(typeof(UTILISATEUR))]
        public IHttpActionResult GetUTILISATEUR(int id)
        {
            UTILISATEUR utilisateur = db.UTILISATEURs.Find(id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            return Ok(utilisateur);
        }

        // PUT api/Utilisateur/5
        public IHttpActionResult PutUTILISATEUR(int id, UTILISATEUR utilisateur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != utilisateur.id)
            {
                return BadRequest();
            }

            db.Entry(utilisateur).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UTILISATEURExists(id))
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

        // POST api/Utilisateur
        [ResponseType(typeof(UTILISATEUR))]
        public IHttpActionResult PostUTILISATEUR(UTILISATEUR utilisateur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UTILISATEURs.Add(utilisateur);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = utilisateur.id }, utilisateur);
        }

        // DELETE api/Utilisateur/5
        [ResponseType(typeof(UTILISATEUR))]
        public IHttpActionResult DeleteUTILISATEUR(int id)
        {
            UTILISATEUR utilisateur = db.UTILISATEURs.Find(id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            db.UTILISATEURs.Remove(utilisateur);
            db.SaveChanges();

            return Ok(utilisateur);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UTILISATEURExists(int id)
        {
            return db.UTILISATEURs.Count(e => e.id == id) > 0;
        }
    }
}
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
    public class ChatEntreUtilisateurController : ApiController
    {
        private appli_androidContext db = new appli_androidContext();

        // GET api/ChatEntreUtilisateur
        public IQueryable<CHAT_ENTRE_UTILISATEURS> GetCHAT_ENTRE_UTILISATEURS()
        {
            return db.CHAT_ENTRE_UTILISATEURS;
        }

        // GET api/ChatEntreUtilisateur/5
        [ResponseType(typeof(CHAT_ENTRE_UTILISATEURS))]
        public IHttpActionResult GetCHAT_ENTRE_UTILISATEURS(int id)
        {
            CHAT_ENTRE_UTILISATEURS chat_entre_utilisateurs = db.CHAT_ENTRE_UTILISATEURS.Find(id);
            if (chat_entre_utilisateurs == null)
            {
                return NotFound();
            }

            return Ok(chat_entre_utilisateurs);
        }

        // PUT api/ChatEntreUtilisateur/5
        public IHttpActionResult PutCHAT_ENTRE_UTILISATEURS(int id, CHAT_ENTRE_UTILISATEURS chat_entre_utilisateurs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chat_entre_utilisateurs.id_utilisateur1)
            {
                return BadRequest();
            }

            db.Entry(chat_entre_utilisateurs).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CHAT_ENTRE_UTILISATEURSExists(id))
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

        // POST api/ChatEntreUtilisateur
        [ResponseType(typeof(CHAT_ENTRE_UTILISATEURS))]
        public IHttpActionResult PostCHAT_ENTRE_UTILISATEURS(CHAT_ENTRE_UTILISATEURS chat_entre_utilisateurs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CHAT_ENTRE_UTILISATEURS.Add(chat_entre_utilisateurs);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CHAT_ENTRE_UTILISATEURSExists(chat_entre_utilisateurs.id_utilisateur1))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = chat_entre_utilisateurs.id_utilisateur1 }, chat_entre_utilisateurs);
        }

        // DELETE api/ChatEntreUtilisateur/5
        [ResponseType(typeof(CHAT_ENTRE_UTILISATEURS))]
        public IHttpActionResult DeleteCHAT_ENTRE_UTILISATEURS(int id)
        {
            CHAT_ENTRE_UTILISATEURS chat_entre_utilisateurs = db.CHAT_ENTRE_UTILISATEURS.Find(id);
            if (chat_entre_utilisateurs == null)
            {
                return NotFound();
            }

            db.CHAT_ENTRE_UTILISATEURS.Remove(chat_entre_utilisateurs);
            db.SaveChanges();

            return Ok(chat_entre_utilisateurs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CHAT_ENTRE_UTILISATEURSExists(int id)
        {
            return db.CHAT_ENTRE_UTILISATEURS.Count(e => e.id_utilisateur1 == id) > 0;
        }
    }
}
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
using WebAPISessie.Models;

namespace WebAPISessie.Controllers
{
    public class SessiesController : ApiController
    {
        private SessionDataAcces db = new SessionDataAcces();

        // GET: api/Sessies
        public IQueryable<Sessie> GetSessies()
        {
            return db.Sessies;
        }

        // GET: api/Sessies/5
        [ResponseType(typeof(Sessie))]
        public IHttpActionResult GetSessie(int id)
        {
            Sessie sessie = db.Sessies.Find(id);
            if (sessie == null)
            {
                return NotFound();
            }

            return Ok(sessie);
        }

        // PUT: api/Sessies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSessie(int id, Sessie sessie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sessie.Id)
            {
                return BadRequest();
            }

            db.Entry(sessie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessieExists(id))
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

        // POST: api/Sessies
        [ResponseType(typeof(Sessie))]
        public IHttpActionResult PostSessie(Sessie sessie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sessies.Add(sessie);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sessie.Id }, sessie);
        }

        // DELETE: api/Sessies/5
        [ResponseType(typeof(Sessie))]
        public IHttpActionResult DeleteSessie(int id)
        {
            Sessie sessie = db.Sessies.Find(id);
            if (sessie == null)
            {
                return NotFound();
            }

            db.Sessies.Remove(sessie);
            db.SaveChanges();

            return Ok(sessie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SessieExists(int id)
        {
            return db.Sessies.Count(e => e.Id == id) > 0;
        }
    }
}
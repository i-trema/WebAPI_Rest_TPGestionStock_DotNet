using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI_RestPremiereApp.Models;

namespace WebAPI_RestPremiereApp.Controllers
{
    public class Abonnes1Controller : ApiController
    {
        private DbAbonnesContext db = new DbAbonnesContext();

        // GET: api/Abonnes1
        public IQueryable<Abonne> GetAbonnes()
        {
            return db.Abonnes;
        }

        // GET: api/Abonnes1/5
        [ResponseType(typeof(Abonne))]
        public async Task<IHttpActionResult> GetAbonne(int id)
        {
            Abonne abonne = await db.Abonnes.FindAsync(id);
            if (abonne == null)
            {
                return NotFound();
            }

            return Ok(abonne);
        }

        // PUT: api/Abonnes1/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAbonne(int id, Abonne abonne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != abonne.Id)
            {
                return BadRequest();
            }

            db.Entry(abonne).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbonneExists(id))
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

        // POST: api/Abonnes1
        [ResponseType(typeof(Abonne))]
        public async Task<IHttpActionResult> PostAbonne(Abonne abonne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Abonnes.Add(abonne);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = abonne.Id }, abonne);
        }

        // DELETE: api/Abonnes1/5
        [ResponseType(typeof(Abonne))]
        public async Task<IHttpActionResult> DeleteAbonne(int id)
        {
            Abonne abonne = await db.Abonnes.FindAsync(id);
            if (abonne == null)
            {
                return NotFound();
            }

            db.Abonnes.Remove(abonne);
            await db.SaveChangesAsync();

            return Ok(abonne);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AbonneExists(int id)
        {
            return db.Abonnes.Count(e => e.Id == id) > 0;
        }
    }
}
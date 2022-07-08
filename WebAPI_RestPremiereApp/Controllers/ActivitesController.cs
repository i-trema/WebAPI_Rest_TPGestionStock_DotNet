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
    public class ActivitesController : ApiController
    {
        private DbAbonnesContext db = new DbAbonnesContext();

        // GET: api/Activites
        public IQueryable<Activite> GetActivites()
        {
            return db.Activites;
        }

        // GET: api/Activites/5
        [ResponseType(typeof(Activite))]
        public async Task<IHttpActionResult> GetActivite(int id)
        {
            Activite activite = await db.Activites.FindAsync(id);
            if (activite == null)
            {
                return NotFound();
            }

            return Ok(activite);
        }

        // PUT: api/Activites/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutActivite(int id, Activite activite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activite.Id)
            {
                return BadRequest();
            }

            db.Entry(activite).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActiviteExists(id))
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

        // POST: api/Activites
        [ResponseType(typeof(Activite))]
        public async Task<IHttpActionResult> PostActivite(Activite activite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Activites.Add(activite);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = activite.Id }, activite);
        }

        // DELETE: api/Activites/5
        [ResponseType(typeof(Activite))]
        public async Task<IHttpActionResult> DeleteActivite(int id)
        {
            Activite activite = await db.Activites.FindAsync(id);
            if (activite == null)
            {
                return NotFound();
            }

            db.Activites.Remove(activite);
            await db.SaveChangesAsync();

            return Ok(activite);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActiviteExists(int id)
        {
            return db.Activites.Count(e => e.Id == id) > 0;
        }
    }
}
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
using WebAPIRest_GestionStock.Models;

namespace WebAPIRest_GestionStock.Controllers
{
    public class ArticlesController : ApiController
    {
        private DbGestionStockRestContext db = new DbGestionStockRestContext();

        // GET: api/Articles
        public IQueryable<Article> GetArticles()
        {
            return db.Articles.Include(a => a.Category);
        }

        // GET: api/Articles/5
        [ResponseType(typeof(Article))]
        public async Task<IHttpActionResult> GetArticle(int id)
        {
            Article article = await db.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        // PUT: api/Articles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutArticle(int id, Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != article.Id)
            {
                return BadRequest();
            }

            db.Entry(article).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(id))
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

        // POST: api/Articles
        [ResponseType(typeof(Article))]
        public async Task<IHttpActionResult> PostArticle(Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Category categoryRecueExiste = db.Categories.Find(article.Categorie_Id);
            if (categoryRecueExiste != null) article.Category = categoryRecueExiste;

            db.Articles.Add(article);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = article.Id }, article);
        }

        // DELETE: api/Articles/5
        [ResponseType(typeof(Article))]
        public async Task<IHttpActionResult> DeleteArticle(int id)
        {
            Article article = await db.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            db.Articles.Remove(article);
            await db.SaveChangesAsync();

            return Ok(article);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArticleExists(int id)
        {
            return db.Articles.Count(e => e.Id == id) > 0;
        }
    }
}
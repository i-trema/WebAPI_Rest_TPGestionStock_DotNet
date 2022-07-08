using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_RestPremiereApp.Models;

namespace WebAPI_RestPremiereApp.Controllers
{
    public class AbonnesEFController : ApiController
    {
        private DbAbonnesContext db = new DbAbonnesContext();

        [HttpGet]
        [Route("api/abonnes/index")]
        //public IQueryable<Abonne> GetAbonnes()
        public IHttpActionResult GetAbonnes()
        {
            return Json(db.Abonnes);
        }

        [HttpPost]
        [Route("api/abonnes/add")]
        public IHttpActionResult AddAbonne(Abonne abonne)
        {
            //if(abonne == null) return false;
            if (ModelState.IsValid)
            {
                db.Abonnes.Add(abonne);
                return Ok(db.SaveChanges() > 0);
            }
                return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("api/abonnes/supp/{id}")]
        public IHttpActionResult SuppAbonne(int? id)
        {
            if (id == null) return BadRequest();
            Abonne AbonneASupprimer = db.Abonnes.FirstOrDefault(x=>x.Id == id); 
            if (AbonneASupprimer == null) return StatusCode(HttpStatusCode.NoContent);
            db.Abonnes.Remove(AbonneASupprimer);
            db.SaveChanges();   
            return Ok();
        }

    }
}

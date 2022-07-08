using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_RestPremiereApp.Models;

namespace WebAPI_RestPremiereApp.Controllers
{
    public class AbonnesController : ApiController
    {
        private static List<Abonne> abonnes = new List<Abonne>();
        // ce contrôleur gère les abonnés
        [HttpGet]
        [Route("api/getabonnes")]
        public List<Abonne> GetAbonnes()
        {
            PreparerListe();
            return abonnes;
        }

        [HttpPost]
        [Route("api/addAbonne")]
        public bool AddAbonne(Abonne abonne)
        {
            abonnes.Add(abonne);
            return true;
        }

        [HttpDelete]
        [Route("api/Supp/{id}")]
        public bool SuppAbonne(int id)
        {
            Abonne AbonneASupprimer = abonnes.SingleOrDefault(x=>x.Id == id); 
            if (AbonneASupprimer == null) return false; 
            return abonnes.Remove(AbonneASupprimer);
        }

        [HttpPut]
        [Route("api/Modif")]
        public bool ModifierAbonne(Abonne abonne)
        {
            Abonne AbonneAModifier = abonnes.SingleOrDefault(x=>x.Id ==abonne.Id);  
            if (AbonneAModifier == null) return false;

            //if(string.IsNullOrEmpty(abonne.Mail))
            if (!string.IsNullOrEmpty(abonne.Mail)) AbonneAModifier.Mail = abonne.Mail;
            if (!string.IsNullOrEmpty(abonne.Prenom)) AbonneAModifier.Prenom = abonne.Prenom;

            return true;
        }

        private void PreparerListe()
        {
            if(abonnes.Count == 0)
            {
                Random rnd = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int nbAleatoire = rnd.Next(1, 100);
                    Abonne a = new Abonne() { Id = nbAleatoire, Prenom = "Prenom " + nbAleatoire, Mail = "Mail" + nbAleatoire };
                    abonnes.Add(a);
                }

            }
        }
    }
}

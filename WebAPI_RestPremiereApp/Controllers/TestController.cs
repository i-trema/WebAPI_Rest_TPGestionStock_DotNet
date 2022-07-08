using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAPI_RestPremiereApp.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("api/jtravail")]
        public string[] Jours()
        {
            return new[] { "lundi", "mardi", "mercredi", "jeudi", "vendredi" };
        }

        [HttpGet]
        [Route("api/jchomes")]
        public string[] JoursChomes()
        {
            return new[] { "samedi", "dimanche" };
        }

        [HttpGet]
        // avec un paramètre, qui se nomme id comme dans la route par défaut : https://localhost:44323/api/test/tomaj/lemotaconvertir
        // ou : https://localhost:44323/api/test/tomaj?id=lemotaconvertir
        public string ToMaj (string id)
            {
                return id.ToUpper();
            }

        [HttpGet]
        // avec plusieurs parametres : https://localhost:44323/api/test/concat?mot1=premiermot&mot2=deuxiememot
        public string Concat(string mot1, string mot2)
        {
            return mot1 + mot2;
        }

        [HttpGet]
        // pr utiliser la syntaxe https://localhost:44323/api/test/tomin/lemotaconvertir :
        [Route("api/tomin/{mot}")]
        public string ToMin(string mot)
        {
            return mot.ToLower();
        }

        //// avec plusieurs params
        [HttpGet]
        // par défaut : https://localhost:44323/api/test/concat2?mot1=premiermot&mot2=deuxiememot
        [Route("api/concat2/{mot1}/{mot2}")]
        public string Concat2 (string mot1, string mot2)
        {
            return mot1 + " " + mot2;
        }

    }
}
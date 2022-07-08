using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_RestPremiereApp.Models
{
    public class Activite
    {
        public int Id { get; set; }
        public string Libelle { get; set; }    
        
        //public ICollection<Abonne> Abonnes { get; set; }
    }
}
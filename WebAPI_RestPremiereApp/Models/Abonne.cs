using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI_RestPremiereApp.Models
{
    public class Abonne

    {
        // ModelState
        public int Id { get; set; }

        [Required(ErrorMessage="Veuillez entrer une valeur")]
        [MaxLength(20, ErrorMessage ="Veuillez ne pas dépasser 20 caractères")]
        [MinLength(2,ErrorMessage ="le prénom est trop court")]
        [DataType(DataType.Text)]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Veuillez entrer une valeur")]
        [EmailAddress]
        public string Mail { get; set; }

        public Activite Activite { get; set; }
    }
}
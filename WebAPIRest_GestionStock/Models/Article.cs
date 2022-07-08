namespace WebAPIRest_GestionStock.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Article
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Champs requis")]
        [MinLength(2, ErrorMessage = "nom trop court")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Champs requis")]
        [Range(0, int.MaxValue)]
        public int? QteMini { get; set; }
        [Required(ErrorMessage = "Champs requis")]
        [Range(0, int.MaxValue)]
        public double? Prix { get; set; }
        
        public int? Categorie_Id { get; set; }

        [StringLength(10)]
        public string info { get; set; }

        public Category Category { get; set; }
    }
}

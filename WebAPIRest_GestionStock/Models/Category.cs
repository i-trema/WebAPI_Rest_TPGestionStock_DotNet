namespace WebAPIRest_GestionStock.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Category()
        //{
        //    Articles = new HashSet<Article>();
        //}

        public int Id { get; set; }
        [Required(ErrorMessage = "Champs requis")]
        [MinLength(2, ErrorMessage = "nom trop court")]
        public string Nom { get; set; }

        public string Info { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public ICollection<Article> Articles { get; set; }
    }
}

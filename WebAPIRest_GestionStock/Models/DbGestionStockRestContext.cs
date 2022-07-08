using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebAPIRest_GestionStock.Models
{
    public partial class DbGestionStockRestContext : DbContext
    {
        public DbGestionStockRestContext()
            : base("name=DbGestionStockRestContext")
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Article>()
        //        .Property(e => e.info)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Category>()
        //        .HasMany(e => e.Articles)
        //        .WithOptional(e => e.Category)
        //        .HasForeignKey(e => e.Categorie_Id);
        //}
    }
}

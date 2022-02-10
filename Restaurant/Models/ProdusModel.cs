using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Languages;

namespace Restaurant.Models
{
    public class ProdusModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nume", ResourceType = typeof(Resource))]
        public string Nume { get; set; }
        [Required]
        [Display(Name = "Gramaj", ResourceType = typeof(Resource))]
        public int Gramaj { get; set; }
        [Required]
        [Display(Name = "Cantitate", ResourceType = typeof(Resource))]
        public int Cantitate { get; set; }
        [Required]
        [Display(Name = "Unitate_masura", ResourceType = typeof(Resource))]
        public string Unitate_masura { get; set; }
    }
    public class ProdusDbContext : DbContext
    {
        public DbSet<ProdusModel> Produse { get; set; }
    }
}
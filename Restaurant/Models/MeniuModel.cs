using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Languages;

namespace Restaurant.Models
{
    public class MeniuModel
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30,ErrorMessage ="Nume meniu prea lung")]
        [Display(Name = "Nume", ResourceType = typeof(Resource))]
        public string Nume { get; set; }
        [Required]
        [Display(Name = "Pret", ResourceType = typeof(Resource))]
        public double Pret { get; set; }
        [Required]
        public string Idproduse { get; set; }
    }
    public class MeniuDbContext : DbContext
    {
        public DbSet<MeniuModel> Meniuri { get; set; }
    }
}
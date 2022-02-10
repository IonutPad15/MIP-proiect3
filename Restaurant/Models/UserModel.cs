using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Languages;

namespace Restaurant.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30,ErrorMessage ="Nume de utilizator prea lung")]
        [Display(Name = "Username", ResourceType = typeof(Resource))]
        public string Username { get; set; }
        [Required]
        [MaxLength(256,ErrorMessage ="Parola prea lunga")]
        [Display(Name = "Password", ResourceType = typeof(Resource))]
        public string Password { get; set; }
        [Required]
        [MaxLength(10,ErrorMessage ="Numar de telefon invalid")]
        [Display(Name = "Nrtel", ResourceType = typeof(Resource))]
        public string Nrtel { get; set; }
    }
    public class UserDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
    }
}
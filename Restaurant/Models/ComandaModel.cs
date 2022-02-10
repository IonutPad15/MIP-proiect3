using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Languages;

namespace Restaurant.Models
{
    public class ComandaModel
    {
        public string Name { get; set; }
        public List<string> updown { get; set; }
    }
    
    //public 
}
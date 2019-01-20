using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ParsingStore_App.Models
{
    [Table("Racket")]
    public class Racket : Product
    {
        public int IDRacket { get; set; }
        public bool isProfessional { get; set; }
        public string Flexibility { get; set; }
        public double MaxTension { get; set; }

        public override Product CreateProduct()
        {
            return new Racket();
        }

        public override object CreateListOfProductFromParsedPage(string url)
        {
            return new List<Racket>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ParsingStore_App.Models
{
    [Table("Shoes")]
    public class Shoes : Product
    {
        public double Size { get; set; }
        public double Model { get; set; }
        public string SoleType { get; set; }
        public bool isBag { get; set; }

        public override Product CreateProduct()
        {
            return new Shoes();
        }

        public override object CreateListOfProductFromParsedPage(string url)
        {
            List<Shoes> shoesList = HelperPageParsingClass.ParseSitePage
               (url); //https://badminton.ua/product-category/krossovki-dlya-badmintona/krossovki-yonex/
            return shoesList;
        }

    }
}
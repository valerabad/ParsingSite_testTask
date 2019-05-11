using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ParsingStore_App.Models
{
    [Table("Сlothes")]
    public  class Сlothes : Product 
    {
        public override Product CreateProduct()
        {
            return new Сlothes();
        }

        public override object CreateListOfProductFromParsedPage(string url)
        {
            return new List<Сlothes>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParsingStore_App.Models
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public byte[] ImageBytes { get; set; }

        public virtual ICollection<HistoryPrice> Enrollments { get; set; }

        public abstract Product CreateProduct();
        public abstract object CreateListOfProductFromParsedPage(string url);
    }
}
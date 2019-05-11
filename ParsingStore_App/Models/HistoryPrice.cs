using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParsingStore_App.Models
{
    public class HistoryPrice
    {
        public int ID { get; set; }
        public int? PriceID { get; set; }
        public int? PriceOnDate { get; set; }
        public DateTime? Date { get; set; }
    }
}
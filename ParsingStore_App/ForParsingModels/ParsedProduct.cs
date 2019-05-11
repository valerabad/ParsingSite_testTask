using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParsingStore_App.Models
{
    [Table("ParsedProduct")]
    public class ParsedProduct
    {
        public int Id { get; set; }
        public string Siteid { get; set; }
        public string Prodid { get; set; }

        string TargetProduct { get; set; } = "Shoes";
        string TitleXPath { get; set; } = "//div";
        string PriseXPath { get; set; } = "//div";
        string DescriptionXPath { get; set; } = "//div";
        string ImageXPath { get; set; } = "//div";    
    }
}

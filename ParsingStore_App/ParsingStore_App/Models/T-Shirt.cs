using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParsingStore_App.Models
{
    interface IClothes
    {
        void ReturnClothes();
        void CheckСlothesCollection();
    }

    enum TypeMaterial
    {
        Synthetics,
        Cotton
    }

    [Table("T_Shirt")]
    public class T_Shirt : Сlothes , IClothes
    {
        public Color Color { get; set; }
        public double Size { get; set; }
        public string Print { get; set; }
        public string TypeMaterial { get; set; }

        public override Product CreateProduct()
        {
            return new T_Shirt();
        }

        public void ReturnClothes()
        { }
        public void CheckСlothesCollection()
        { }
    }
}
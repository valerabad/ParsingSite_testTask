using System;
using System.Collections.Generic;
using ParsingStore_App.Models;
using System.Data.Entity;

namespace ParsingStore_App.DAL
{
    public class ProductInitializer : DropCreateDatabaseAlways<ProductContext> //DropCreateDatabaseIfModelChanges
    {
        public string GetAllSites()
        {
            // заглушка для теста
            return "https://badminton.ua/product/category/krossovki-dlya-badmintona/krossovki-fz-forza/";
        }

        public Product GetProductbySite(string siteUrl)
        {
            return new Shoes();
        }

        public void SaveProductToDB()
        {

        }

        protected override void Seed(ProductContext context)
        {
            string selectedSiteUrl = GetAllSites();
            Product selectedProduct = GetProductbySite(selectedSiteUrl);
            SaveProductToDB();


            Product shoes = new Shoes();
            List<Shoes> shoesList = (List<Shoes>)shoes.CreateListOfProductFromParsedPage
                (@"https://badminton.ua/product/category/krossovki-dlya-badmintona/krossovki-fz-forza/"); // https://badminton.ua/product-category/krossovki-dlya-badmintona/krossovki-yonex/

            foreach (Shoes curProduct in shoesList)
            {
                context.Shoes.Add(curProduct);
            }

            context.SaveChanges();
        }
    }
    }
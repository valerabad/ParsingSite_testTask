using System;
using System.Collections.Generic;
using ParsingStore_App.Models;
using System.Linq;
using System.Web;

namespace ParsingStore_App.DAL
{
    public class ProductInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {           
            // example for demonstrate OOP, EF, mapping to db            
            Product shoes = new Shoes();
            List<Shoes> shoesList = (List<Shoes>)shoes.CreateListOfProductFromParsedPage
                (@"https://badminton.ua/product-category/krossovki-dlya-badmintona/krossovki-yonex/");
            
                foreach (Shoes curProduct in shoesList)
                {
                    context.Shoes.Add(curProduct);
                }
                
                context.SaveChanges();               
            }
        }
    }
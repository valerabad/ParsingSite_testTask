using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using ParsingStore_App.Models;

namespace ParsingStore_App
{
    static public class HelperPageParsingClass
    {
        public static List<Shoes> ParseSitePage(string url)
        {
            var pageContent = LoadPage(url);
            var document = new HtmlDocument();
            document.LoadHtml(pageContent);

            // parse product title
            HtmlNodeCollection titleNodes = document.DocumentNode.SelectNodes
                (".//div[@class='vgwc-image-block']/a");

            List<Shoes> productList = new List<Shoes>();
            foreach (HtmlNode titleProd in titleNodes)
            {
                string title = titleProd.GetAttributeValue("title", null);
                productList.Add(new Shoes { Title = title });

            }

            // parse Description about product
            HtmlNodeCollection desc = document.DocumentNode.SelectNodes
                (".//div[@class='product-desc']/p[1]");
            int n = 0;
            foreach (HtmlNode description in desc)
            {
                productList.ElementAt(n++).Description = description.InnerText;
            }

            // parse product Price
            HtmlNodeCollection prices = document.DocumentNode.SelectNodes
               (".//div[@class='listview']//div[@class='vgwc-text-block']//" +
               "div[@class='vgwc-product-price price-variable']");
            int j = 0;
            foreach (HtmlNode price in prices)
            {
                if (price != null)
                {
                    string decodedString = price.LastChild.InnerText.Replace("&nbsp;&#8372;", " грн."); // ₴
                    productList.ElementAt(j++).Price = (decodedString);
                }
            }

            // parce product image
            HtmlNodeCollection imgs = document.DocumentNode.SelectNodes
              (".//a//img");
            int k = 0;
            foreach (HtmlNode imgUrl in imgs)
            {
                string urlImage = imgUrl.GetAttributeValue("data-lazy-src", null);

                Shoes prod = new Shoes();

                if (urlImage != null)
                {
                    Image imageCurProd = DownloadImageByUrl(@"https:" + urlImage);
                    byte[] bytesArrForImage = imageToByteArray(imageCurProd);
                    //productList.ElementAt(k++).ImageBytes = bytesArrForImage.Select(a=>(byte?)a).ToArray();
                    productList.ElementAt(k++).ImageBytes = bytesArrForImage;
                }


            }

            return productList;
        }

        static string LoadPage(string url)
        {
            var result = "";
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var receiveStream = response.GetResponseStream();
                if (receiveStream != null)
                {
                    StreamReader readStream;
                    if (response.CharacterSet == null)
                        readStream = new StreamReader(receiveStream);

                    else
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    result = readStream.ReadToEnd();
                    readStream.Close();
                }
                response.Close();
            }
            return result;
        }

        public static Image DownloadImageByUrl(string imageUrl)
        {
            Image image = null;
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.
                    Create(imageUrl); 
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;

                System.Net.WebResponse webResponse = webRequest.GetResponse();

                System.IO.Stream stream = webResponse.GetResponseStream();

                image = System.Drawing.Image.FromStream(stream);

                webResponse.Close();
            }
            catch (Exception ex)
            {
                return null;
            }

            return image;
        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return (ms.ToArray());
        }
    }
}
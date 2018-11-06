using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Net;

namespace OpenHouseProject
{
    class FurnitureRepository
    {
        public FurnitureRepository()
        {
#if DEBUG
            string jsonText = File.ReadAllText("appsettings.development.json");
#else
           string jsonText = File.ReadAllText("appsettings.development.json");
#endif
            string connString = JObject.Parse(jsonText)["ConnectionStrings"]["DefaultConnection"].ToString();

            this.connStr = connString;
        }

        public string connStr;

        public List<Furniture> ShowAllProducts()
        {
            Console.WriteLine("ID  Name     Price");
            MySqlConnection thing = new MySqlConnection(connStr);
            List<Furniture> products = new List<Furniture>();
            using (thing)
            {
                thing.Open();
                MySqlCommand cmd = thing.CreateCommand();
                cmd.CommandText = "SELECT * FROM products";
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Furniture product = new Furniture()
                    {
                        Id = (int)rdr["Id"],
                        Name = rdr["Name"].ToString(),
                        Price = (double)rdr["Price"],
                    };
                    products.Add(product);
                    Console.WriteLine($"{product.Id}.....{product.Name}.....{product.Price}");
                }

                return products;
            }
        }
        public List<Furniture> ShowSpecificFurniture(Furniture thing)
        {
            MySqlConnection thing2 = new MySqlConnection(connStr);
            List<Furniture> furnitures = new List<Furniture>();
            using (thing2)
            {
                thing2.Open();
                MySqlCommand cmd = thing2.CreateCommand();
                cmd.CommandText = "Select * from products Where id = @id";
                cmd.Parameters.AddWithValue("id", thing.Id);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Furniture product = new Furniture()
                    {
                        Id = (int)rdr["Id"],
                        Name = thing.Name,
                        Price = thing.Price
                    };
                    furnitures.Add(product);
                    Console.WriteLine($"{product.Id}.....{product.Name}.....{product.Price}");
                }

                return furnitures;

            }
        }
    }
}

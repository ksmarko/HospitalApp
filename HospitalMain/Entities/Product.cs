using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAP.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dimensions { get; set; }
        public int Price { get; set; }
        public string Producer { get; set; }
        public string Additionally { get; set; }

        public Product(string name, string dim, int price, string producer, string add)
        {
            Name = name;
            Dimensions = dim;
            Price = price;
            Producer = producer;
            Additionally = add;
        }
    }
}

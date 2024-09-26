using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDE_POO
{
    internal class Product(string name, int quantity, decimal price)
    {
        public string? Name { get; set; } = name;
        public int Quantity { get; set; } = quantity;
        public decimal Price { get; set; } = price;

        public override string ToString()
        {
            return $"Name: {Name}, Quantity: {Quantity}, Price: R${Price:F2}";
        }
    }
}

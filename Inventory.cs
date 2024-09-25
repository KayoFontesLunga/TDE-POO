using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDE_POO 
{
    internal class Inventory
    {
        private readonly List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
            Console.WriteLine("Product added successfully!\n");
        }

        public void ListProducts()
        {
            Console.WriteLine("\n--- Products in Inventory ---");
            if (products.Count == 0)
            {
                Console.WriteLine("No products registered.");
            }
            else
            {
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {products[i]}");
                }
            }
            Console.WriteLine();
        }

        public void EditProduct(int index, Product newProduct)
        {
            if (index >= 0 && index < products.Count)
            {
                products[index] = newProduct;
                Console.WriteLine("Product updated successfully!\n");
            }
            else
            {
                Console.WriteLine("Invalid index!\n");
            }
        }

        public void RemoveProduct(int index)
        {
            if (index >= 0 && index < products.Count)
            {
                products.RemoveAt(index);
                Console.WriteLine("Product successfully removed!\n");
            }
            else
            {
                Console.WriteLine("Invalid index!\n");
            }
        }
    }
}

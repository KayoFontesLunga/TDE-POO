using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDE_POO
{
    internal class Inventory
    {
        private readonly List<Product> product = [];

        public void AddProduct(Product Product)
        {
            product.Add(Product);
            Console.WriteLine("Product added successfully!\n");
        }

        public void ListProducts()
        {
            Console.WriteLine("\n--- Products in Inventory ---");
            if (product.Count == 0)
            {
                Console.WriteLine("No Product registered.");
            }
            else
            {
                for (int i = 0; i < product.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {product[i]}");
                }
            }
            Console.WriteLine();
        }

        public void EditProduct(int i, Product newProduct)
        {
            if (i >= 0 && i < product.Count)
            {
                product[i] = newProduct;
                Console.WriteLine("Product updated successfully!\n");
            }
            else
            {
                Console.WriteLine("Invalid index!\n");
            }
        }

        public void RemoveProduct(int i)
        {
            if (i >= 0 && i < product.Count)
            {
                product.RemoveAt(i);
                Console.WriteLine("Product successfully removed!\n");
            }
            else
            {
                Console.WriteLine("Invalid index!\n");
            }
        }
    }
}

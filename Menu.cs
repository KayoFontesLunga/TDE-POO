using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TDE_POO
{
    internal class Menu
    {
        private static Inventory inventory = new Inventory();
        public static void Show()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            DrawScreen();
            WriteOption();

            int option = -1;
            while (option < 0 || option > 4)
            {
                var input = Console.ReadLine();
                if (!int.TryParse(input, out option) || option < 0 || option > 4)
                {
                    Console.WriteLine("\nInvalid option. Please enter a value between 0 and 4.");
                    Console.Write("\nEnter the amount again: ");
                }
            }

            HandleMenuOption(option);
        }
        public static void DrawScreen()
        {
            Line01();
            Colunes();
            Line01();
        }
        static void Line01()
        {
            Console.Write("+");
            for (int i = 0; i <= 30; i += 1)
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.Write("\n");
        }
        static void Colunes()
        {
            for (int line = 0; line <= 10; line += 1)
            {
                Console.Write("|");
                for (int i = 0; i <= 30; i += 1)
                {
                    Console.Write(" ");
                }
                Console.Write("|");
                Console.Write("\n");
            }
        }
        public static void WriteOption()
        {
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("Inventory Management System");

            Console.SetCursorPosition(3, 3);
            Console.WriteLine("===========");

            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Select an option below:");

            Console.SetCursorPosition(3, 6);
            Console.WriteLine("1. Add Product");

            Console.SetCursorPosition(3, 7);
            Console.WriteLine("2. List Products");

            Console.SetCursorPosition(3, 8);
            Console.WriteLine("3. Edit Product");

            Console.SetCursorPosition(3, 9);
            Console.WriteLine("4. Remove Product");

            Console.SetCursorPosition(3, 10);
            Console.WriteLine("0. Exit");

            Console.SetCursorPosition(3, 11);
            Console.Write("Choose an option: ");
        }
        public static void HandleMenuOption(int option)
        {
            switch (option)
            {
                case 1:
                    AddNewProduct();
                    break;
                case 2:
                    ListProducts();
                    break;
                case 3:
                    EditProductOption();
                    break;
                case 4:
                    RemoveProductOption();
                    break;
                case 0:
                    Finalization();
                    Environment.Exit(0);
                    break;
                default:
                    Show();
                    break;
            }
            Show();
        }
        public static void AddNewProduct()
        {
            string? name = null;
            int quantity = 0;
            decimal price = 0;
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("\nEnter product name: ");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("\nInvalid name. Please enter a valid product name.");
                }
            }
            bool validQuantity = false;
            while (!validQuantity)
            {
                Console.Write("Enter product quantity: ");
                var inputQuantity = Console.ReadLine();

                if (!int.TryParse(inputQuantity, out quantity) || quantity < 0)
                {
                    Console.WriteLine("\nInvalid quantity. Please enter a valid positive number.");
                }
                else
                {
                    validQuantity = true;
                }
            }
            bool validPrice = false;
            while (!validPrice)
            {
                Console.Write("Enter product price: ");
                var inputPrice = Console.ReadLine();

                if (!decimal.TryParse(inputPrice, out price) || price < 0)
                {
                    Console.WriteLine("\nInvalid price. Please enter a valid positive number.");
                }
                else
                {
                    validPrice = true;
                }
            }
            var product = new Product(name, quantity, price);
            inventory.AddProduct(product);

            Console.WriteLine("Product added successfully.");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
        public static void ListProducts()
        {
            inventory.ListProducts();

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey(); 
        }
        public static void EditProductOption()
        {
            inventory.ListProducts();
            int index = -1;
            bool validIndex = false;
            while (!validIndex)
            {
                Console.Write("Enter the product number to edit: ");
                var inputIndex = Console.ReadLine();

                if (!int.TryParse(inputIndex, out index) || index <= 0 || index > inventory.GetProductCount())
                {
                    Console.WriteLine("\nInvalid product number. Please enter a valid number.");
                }
                else
                {
                    index -= 1;
                    validIndex = true;
                }
            }
            string? newName = null;
            while (string.IsNullOrWhiteSpace(newName))
            {
                Console.Write("Enter new product name: ");
                newName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newName))
                {
                    Console.WriteLine("\nInvalid name. Please enter a valid product name.");
                }
            }
            int newQuantity = 0;
            bool validQuantity = false;
            while (!validQuantity)
            {
                Console.Write("Enter new product quantity: ");
                var inputQuantity = Console.ReadLine();

                if (!int.TryParse(inputQuantity, out newQuantity) || newQuantity < 0)
                {
                    Console.WriteLine("\nInvalid quantity. Please enter a valid positive number.");
                }
                else
                {
                    validQuantity = true;
                }
            }
            decimal newPrice = 0;
            bool validPrice = false;
            while (!validPrice)
            {
                Console.Write("Enter new product price: ");
                var inputPrice = Console.ReadLine();

                if (!decimal.TryParse(inputPrice, out newPrice) || newPrice < 0)
                {
                    Console.WriteLine("\nInvalid price. Please enter a valid positive number.");
                }
                else
                {
                    validPrice = true;
                }
            }
            var newProduct = new Product(newName, newQuantity, newPrice);
            inventory.EditProduct(index, newProduct);

            Console.WriteLine("Product updated successfully.");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
        public static void RemoveProductOption()
        {
            inventory.ListProducts();
            int index = -1;
            bool validIndex = false;
            while (!validIndex)
            {
                Console.Write("Enter the product number to remove: ");
                var inputIndex = Console.ReadLine();

                if (!int.TryParse(inputIndex, out index) || index <= 0 || index > inventory.GetProductCount() || index < 0 )
                {
                    Console.WriteLine("\nInvalid product number. Please enter a valid number.");
                }
                else
                {
                    index -= 1;
                    validIndex = true;
                }
            }
            inventory.RemoveProduct(index);

            Console.WriteLine("Product removed successfully.");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
        public static void Finalization()
        {
            Thread.Sleep(1000);
            Console.WriteLine("\nExiting the application...");
            Thread.Sleep(1000);
        }
    }
}
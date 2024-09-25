using System;
using System.Collections.Generic;
using System.Linq;
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
            while (option < 0 || option > 5)
            {
                var input = Console.ReadLine();
                if (!int.TryParse(input, out option) || option < 0 || option > 5)
                {
                    Console.WriteLine("Invalid option. Please enter a value between 0 and 5.");
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
            Console.WriteLine("5. Exit");

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
                case 5:
                    Finalization();
                    Environment.Exit(0);
                    break;
                default:
                    Show();
                    break;
            }

            // Após a ação, o menu é mostrado novamente.
            Show();
        }

        public static void AddNewProduct()
        {
            Console.WriteLine("\nEnter product name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter product quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter product price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            var product = new Product(name, quantity, price);
            inventory.AddProduct(product);

            Console.WriteLine("Product added successfully!");
        }

        public static void ListProducts()
        {
            inventory.ListProducts();

            // Pausa para o usuário ver a lista antes de voltar ao menu
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey(); // Aguarda até que o usuário pressione qualquer tecla
        }

        public static void EditProductOption()
        {
            inventory.ListProducts();
            Console.WriteLine("Enter the product number to edit: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Enter new product name: ");
            string newName = Console.ReadLine();

            Console.WriteLine("Enter new product quantity: ");
            int newQuantity = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter new product price: ");
            decimal newPrice = decimal.Parse(Console.ReadLine());

            var newProduct = new Product(newName, newQuantity, newPrice);
            inventory.EditProduct(index, newProduct);
        }

        public static void RemoveProductOption()
        {
            inventory.ListProducts();
            Console.WriteLine("Enter the product number to remove: ");
            int index = int.Parse(Console.ReadLine()) - 1;
            inventory.RemoveProduct(index);
        }

        public static void Finalization()
        {
            Thread.Sleep(1000);
            Console.WriteLine("\nExiting the application...");
            Thread.Sleep(1000);
        }
    }
}
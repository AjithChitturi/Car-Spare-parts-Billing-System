using System;
using System.Collections.Generic;

namespace CarSparePartsBillingSystem
{
    class Program
    {
        // Dictionary of products and their respective prices
        static Dictionary<int, Dictionary<string, object>> products = new Dictionary<int, Dictionary<string, object>>()
        {
            { 1, new Dictionary<string, object> { { "name", "Piston" }, { "price", 100 } } },
            { 2, new Dictionary<string, object> { { "name", "Crankshaft" }, { "price", 200 } } },
            { 3, new Dictionary<string, object> { { "name", "Valve" }, { "price", 50 } } },
            { 4, new Dictionary<string, object> { { "name", "Battery" }, { "price", 150 } } },
            { 5, new Dictionary<string, object> { { "name", "Alternator" }, { "price", 300 } } },
            { 6, new Dictionary<string, object> { { "name", "Starter Motor" }, { "price", 200 } } },
            { 7, new Dictionary<string, object> { { "name", "Shock Absorber" }, { "price", 80 } } },
            { 8, new Dictionary<string, object> { { "name", "Strut Mount" }, { "price", 60 } } },
            { 9, new Dictionary<string, object> { { "name", "Control Arm" }, { "price", 120 } } }
        };

        static int SelectProduct()
        {
            while (true)
            {
                Console.WriteLine("Available Products:");
                foreach (var product in products)
                {
                    Console.WriteLine($"{product.Key}. {product.Value["name"]}");
                }

                Console.Write("Select a product (or 'q' to quit): ");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "q")
                    return -1;

                if (int.TryParse(input, out int productIndex) && products.ContainsKey(productIndex))
                    return productIndex;

                Console.WriteLine("Invalid product index. Please try again.");
            }
        }

        static void GenerateQuote(int productIndex, int quantity)
        {
            var product = products[productIndex];
            int price = (int)product["price"];
            int totalCost = price * quantity;

            string currentDate = DateTime.Today.ToString("yyyy-MM-dd");
            Console.Write("Enter car number: ");
            string carNumber = Console.ReadLine();
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            Console.WriteLine("Quote Details:");
            Console.WriteLine($"Username: {username}");
            Console.WriteLine($"Date: {currentDate}");
            Console.WriteLine($"Product: {product["name"]}");
            Console.WriteLine($"Quantity: {quantity}");
            Console.WriteLine($"Total Cost: ${totalCost}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Car Spare Parts Billing System");
            Console.WriteLine("------------------------------");

            while (true)
            {
                int productIndex = SelectProduct();
                if (productIndex == -1)
                    break;

                Console.Write("Enter the quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                GenerateQuote(productIndex, quantity);
            }
        }
    }
}

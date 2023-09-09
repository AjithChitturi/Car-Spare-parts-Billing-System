using System;
using System.Collections.Generic;

namespace CarSparePartsBillingSystem
{
    class Program
    {
        // Dictionary of product categories and their respective prices
        static Dictionary<int, Dictionary<string, object>> productCategories = new Dictionary<int, Dictionary<string, object>>()
        {
            { 1, new Dictionary<string, object>
                {
                    { "name", "Engine Parts" },
                    { "products", new Dictionary<int, Dictionary<string, object>>
                        {
                            { 1, new Dictionary<string, object> { { "name", "Piston" }, { "price", 100 } } },
                            { 2, new Dictionary<string, object> { { "name", "Crankshaft" }, { "price", 200 } } },
                            { 3, new Dictionary<string, object> { { "name", "Valve" }, { "price", 50 } } }
                        }
                    }
                }
            },
            { 2, new Dictionary<string, object>
                {
                    { "name", "Electrical Parts" },
                    { "products", new Dictionary<int, Dictionary<string, object>>
                        {
                            { 1, new Dictionary<string, object> { { "name", "Battery" }, { "price", 150 } } },
                            { 2, new Dictionary<string, object> { { "name", "Alternator" }, { "price", 300 } } },
                            { 3, new Dictionary<string, object> { { "name", "Starter Motor" }, { "price", 200 } } }
                        }
                    }
                }
            },
            { 3, new Dictionary<string, object>
                {
                    { "name", "Suspension Parts" },
                    { "products", new Dictionary<int, Dictionary<string, object>>
                        {
                            { 1, new Dictionary<string, object> { { "name", "Shock Absorber" }, { "price", 80 } } },
                            { 2, new Dictionary<string, object> { { "name", "Strut Mount" }, { "price", 60 } } },
                            { 3, new Dictionary<string, object> { { "name", "Control Arm" }, { "price", 120 } } }
                        }
                    }
                }
            }
        };

        static void DisplayCategories()
        {
            Console.WriteLine("Available Categories:");
            foreach (var category in productCategories)
            {
                Console.WriteLine($"{category.Key}. {category.Value["name"]}");
            }
        }

        static int? SelectCategory()
        {
            while (true)
            {
                Console.Write("Select a category by index (or 'q' to quit): ");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "q")
                    return null;

                if (int.TryParse(input, out int categoryIndex) && productCategories.ContainsKey(categoryIndex))
                    return categoryIndex;

                Console.WriteLine("Invalid category index. Please try again.");
            }
        }

        static int SelectProduct(int categoryIndex)
        {
            var category = productCategories[categoryIndex];
            var products = (Dictionary<int, Dictionary<string, object>>)category["products"];

            while (true)
            {
                Console.WriteLine($"Available {category["name"]} Products:");
                foreach (var product in products)
                {
                    Console.WriteLine($"{product.Key}. {product.Value["name"]}");
                }

                Console.Write("Select a product (or 'q' to go back): ");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "q")
                    return -1;

                if (int.TryParse(input, out int productIndex) && products.ContainsKey(productIndex))
                    return productIndex;

                Console.WriteLine("Invalid product index. Please try again.");
            }
        }

        static void GenerateQuote(int categoryIndex, int productIndex, int quantity)
        {
            var category = productCategories[categoryIndex];
            var products = (Dictionary<int, Dictionary<string, object>>)category["products"];
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
            Console.WriteLine($"Category: {category["name"]}");
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
                DisplayCategories();
                int? categoryIndex = SelectCategory();
                if (categoryIndex == null)
                    break;

                int productIndex = SelectProduct(categoryIndex.Value);
                if (productIndex == -1)
                    continue;

                Console.Write("Enter the quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                GenerateQuote(categoryIndex.Value, productIndex, quantity);
            }
        }
    }
}

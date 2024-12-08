using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LindasPetShop;


namespace LindasPetShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sup Fool!");
            Console.WriteLine("Press 1 to add a product");
            Console.WriteLine("Press 2 to find your item");
            Console.WriteLine("Press 8 to view all your products, incase you forgot!");
            Console.WriteLine("Press 7 to get a list of in stock products");
            Console.WriteLine("Type 'exit' to quit");

            ProductLogic productLogic = new ProductLogic();

            Console.WriteLine("all yah stuff");
            foreach (var product in productLogic.GetAllProduct())
            {
                Console.WriteLine($"{product.Name}, Quantity {product.Quantity}, Price ${product.Price}");
            }

            Console.WriteLine("\nIn-Stock Products:");
            foreach (var productName in productLogic.GetOnlyInStockProducts())
            {
                Console.WriteLine(productName);
            }

            decimal totalPrice = productLogic.GetTotalPriceOfInventory();
            Console.WriteLine($"\nTotal Price of In-Stock Inventory: ${totalPrice}");

            string userInput = Console.ReadLine();

            while (userInput.ToLower() != "exit")
            {

                if (userInput == "2")
                {
                    Console.WriteLine("enter the name of the item that you want to find!");
                    string leashName = Console.ReadLine();

                    DogLeash retrievedLeash = productLogic.GetDogLeashByName(leashName);

                    if (retrievedLeash != null)
                    {
                        Console.WriteLine($"Retrived Dog Leash: Name: {retrievedLeash.Name} material: {retrievedLeash.Material}");
                    }
                    else
                    {
                        Console.WriteLine("No dog leash found with that name");
                    }
                }
                else if (userInput == "8")
                {
                    List<Product> allProducts = productLogic.GetAllProduct();

                    foreach (Product product in allProducts)
                    {
                        Console.WriteLine(product.Name);
                    }

                }
                else if (userInput == "1")
                {
                    DogLeash dogLeash = new DogLeash();

                    Console.WriteLine("Enter the name of your dog leash! Please! HURRY! Five, four, just kidding...");
                    dogLeash.Name = Console.ReadLine();

                    Console.WriteLine("Enter how much the darn dog leash cost!: ");
                    dogLeash.Price = decimal.Parse(Console.ReadLine());

                    Console.WriteLine("Enter how many you got RIGHT NOW! (of the dog leashes): ");
                    dogLeash.Quantity = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter a description of your amazing dog leash: ");
                    dogLeash.Description = Console.ReadLine();

                    Console.WriteLine("Enter the length in inches (please): ");
                    dogLeash.LengthInches = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the amazing material of the dog leash: ");
                    dogLeash.Material = Console.ReadLine();

                    productLogic.AddProduct(dogLeash);

                    Console.WriteLine($"Product '{dogLeash.Name}' has been added to the darn list");
                }
                else if (userInput == "7")
                {
                    List<string> inStockProducts = productLogic.GetOnlyInStockProducts();

                    Console.WriteLine("In Stock Stuff");
                    foreach (var productName in inStockProducts)
                    {
                        Console.WriteLine(productName);
                    }
                }

                    Console.WriteLine("Press 1 to add Product");
                    Console.WriteLine("Press 2 to find your item");
                    Console.WriteLine("Press 7 to get a list of in stock products");
                    Console.WriteLine("Press 8 to view all your products, incase you forgot!");
                    Console.WriteLine("Type 'exit' to quit");
                    userInput = Console.ReadLine();

            }
        }
    }
}

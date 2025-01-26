using PetStore.Data;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace LindasPetShop
{
    public class UIlogic
    {
        private readonly IProductLogic _productLogic;

        public UIlogic()
        {
            IProductRepository productRepository = new ProductRepository(new ProductContext());
            _productLogic = new ProductLogic(productRepository);
        }

        public void Start()
        {
            DisplayWelcomeMessage();
            string userInput;

            do
            {
                DisplayMenu();
                userInput = Console.ReadLine()?.ToLower();

                switch (userInput)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        FindProduct();
                        break;
                    case "7":
                        DisplayInStockProducts();
                        break;
                    case "8":
                        DisplayAllProducts();
                        break;
                    case "exit":
                        Console.WriteLine("Bye Bye Bye");
                        break;
                    default:
                        Console.WriteLine("No no no, dont do that");
                        break;
                }
            } while (userInput != "exit");
        }

        private void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to yah girls, Lindas's Pet Shop!");
        }

        private void DisplayMenu()
        {
            Console.WriteLine("/nMenu:");
            Console.WriteLine("1-Add a product");
            Console.WriteLine("2-Find a product");
            Console.WriteLine("7-View in-stock stuff");
            Console.WriteLine("8- View all products and stuff");
            Console.WriteLine("Type 'exit' to quit");
            Console.WriteLine("You gets to pick now");
            Console.WriteLine();
            Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _");
            Console.WriteLine();
        }

        private void AddProduct()
        {
            Console.WriteLine("Enter product details:");

            try
            {
                // input prompts
                Console.WriteLine("Enter Product Name");
                string name = Console.ReadLine();
                
                Console.Write("Enter product Id: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter product price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.Write("Enter product quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Console.Write("Enter product description: ");
                string description = Console.ReadLine();

                Console.Write("Enter leash length (in inches): ");
                int lengthInches = int.Parse(Console.ReadLine());

                Console.Write("Enter leash material: ");
                string material = Console.ReadLine();

                // Step 1: Build an object
                var dogLeashObject = new DogLeash
                {
                    Name = name,
                    Id = id,
                    Price = price,
                    Quantity = quantity,
                    Description = description,
                    LengthInches = lengthInches,
                    Material = material
                };

                // Step 2: Convert object into JSON
                string jsonInput = JsonSerializer.Serialize(dogLeashObject);
                Console.WriteLine($"\nGenerated JSON: {jsonInput}"); 

                // Step 3: Deserialize the JSON back 
                DogLeash dogLeash = JsonSerializer.Deserialize<DogLeash>(jsonInput);

                if (dogLeash != null)
                {
                    // Step 4: Add product
                    _productLogic.AddProduct(dogLeash);
                    Console.WriteLine($"Product '{dogLeash.Id}' added successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to create product from input.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please make sure to enter numbers for price, quantity, and length.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        private void FindProduct()
        {
            string productName = PromptInput("Enter the dang Id of your product name:");

            if (int.TryParse(productName, out int id))
            {
                Product product = _productLogic.GetProductById(id);
                if (product != null)
                {
                    Console.WriteLine($"Product found: {product.Id}, Material: {product.Name}");
                }
                else
                {
                    Console.WriteLine("Product not found bruva");
                }
            }
            else
            {
                Console.WriteLine("invail Id enter, please try again");
            }
        }

        private void DisplayInStockProducts()
        {
            Console.WriteLine("/nIn-Stock Products:");
            foreach (var product in _productLogic.GetOnlyInStockProducts())
            {
                Console.WriteLine(product);
            }
        }

        private void DisplayAllProducts()
        {
            Console.WriteLine("/nAll Products:");
            foreach (var product in _productLogic.GetAllProduct())
            {
                Console.WriteLine($"{product.Id}, Quantity: {product.Quantity}, Price:$ {product.Price}");
            }
        }

        private string PromptInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("Type 'exit' to quit");
            
            string userInput = Console.ReadLine();

            while (userInput.ToLower() != "exit")
            {
                if(userInput == "1")
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

                    Console.WriteLine(JsonSerializer.Serialize(dogLeash));
                }

                Console.WriteLine("Press 1 to add Product");
                Console.WriteLine("Type 'exit' to quit");
                userInput = Console.ReadLine();

            }

        }
    }
}

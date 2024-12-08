using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindasPetShop
{
    internal class ProductLogic : IProductLogic
    {
        private List<Product> _products;
        Dictionary<string, DogLeash> dogLeashes = new Dictionary<string, DogLeash>();
        Dictionary<string, CatFood> catFoods = new Dictionary<string, CatFood>();

        public ProductLogic()
        {
            _products = new List<Product>
            {
                new DogLeash { Name = "normal Leash", Price = 10.99m, Quantity = 5 },
                new DogLeash { Name = "Fancy Leash", Price = 19.99m, Quantity = 0 },
                new CatFood { Name = "Kitty Kibble", Price = 5.99m, Quantity = 10 }
            };
        }
        public void AddProduct(Product product)
        {
            _products.Add(product);

            if (product is DogLeash dogLeash)
            {
                dogLeashes[product.Name] = dogLeash;
            }
            else if (product is CatFood catFood)
            {
                catFoods[product.Name] = catFood;
            }
        }
        public List<Product> GetAllProduct()
        {
            return _products;
        }
        public DogLeash GetDogLeashByName(string name)
        {
            try
            {
                return dogLeashes[name];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
        public List<string> GetOnlyInStockProducts()
        {
            return _products.InStock().Select(product => product.Name).ToList();
        }
        public decimal GetTotalPriceOfInventory()
        {
            return _products.InStock().Select(product => product.Price).Sum();
        }
    }
}

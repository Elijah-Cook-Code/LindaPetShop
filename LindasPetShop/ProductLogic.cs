using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace LindasPetShop
{
    public class ProductLogic : IProductLogic
    {
        private readonly IList<Product> _products;
        private readonly IDictionary<string, DogLeash> _dogLeash;
        private readonly DogLeashValidator _dogLeashValidator;

        public ProductLogic()
        {
            _products = new List<Product>
            {
                new DogLeash { Name = "normal Leash", Price = 10.99m, Quantity = 5 },
                new DogLeash { Name = "Fancy Leash", Price = 19.99m, Quantity = 0 },
                new CatFood { Name = "Kitty Kibble", Price = 5.99m, Quantity = 10 }
            };
            _dogLeash = new Dictionary<string, DogLeash>();
            _dogLeashValidator = new DogLeashValidator();
        }
        public void AddProduct(Product product)
        {
            if (product is DogLeash dogLeash)
            {
                var validationResult = _dogLeashValidator.Validate(dogLeash);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }
            }
            
            _products.Add(product);

            if (product is DogLeash leash)
            {
                _dogLeash[leash.Name] = leash;
            }
        }
        public List<Product> GetAllProduct() => _products.ToList();

        public T GetProductByName<T>(string name) where T : Product
        {
            var product = _products.OfType<T>().FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return product;
        }
        public List<string> GetOnlyInStockProducts()
        {
            return _products.Where(product => product.Quantity > 0).Select(product => product.Name).ToList();
        }
        public decimal GetTotalPriceOfInventory()
        {
            return _products.Where(product => product.Quantity > 0).Sum(product => product.Price * product.Quantity);
        }
    }
}

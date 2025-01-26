using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PetStore.Data;

namespace LindasPetShop
{
    public class ProductLogic : IProductLogic  //errors are because I removed the dog leash class
    {
        private readonly IList<Product> _products;
        private readonly IDictionary<string, DogLeash> _dogLeash;
        private readonly DogLeashValidator _dogLeashValidator;
        private readonly IProductRepository _productRepository;

        public ProductLogic(IProductRepository productRepository)
        {
            _productRepository = productRepository; //cs0266
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

            var productEntity = new ProductEntity
            {
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity, 
                Description = product.Description,
            };

            _productRepository.AddProduct(productEntity); //cs1526

            if (product is DogLeash leash)
            {
                _dogLeash[leash.Name] = leash;
            }
        }
        public List<Product> GetAllProduct() => _products.ToList();

        public Product GetProductById(int id)
        {
            var productEntity = _productRepository.GetProductId(id);

            if (productEntity != null)
            {
                // Convert ProductEntity to Product and return it
                return new Product
                { 
                    Id = productEntity.ProductId,
                    Name = productEntity.Name,
                    Price = productEntity.Price,
                    Quantity = productEntity.Quantity, // Use Quantity
                    Description = productEntity.Description,
                };
            }

            return null;
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

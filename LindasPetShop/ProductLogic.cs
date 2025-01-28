using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PetStore.Data;

namespace LindasPetShop
{
    public class ProductLogic : IProductLogic  //errors are because I removed the dog leash class
    {
        private readonly IValidator<Product> _productValidator;
        private readonly IProductRepository _productRepository;

        public ProductLogic(IProductRepository productRepository, IValidator<Product> productValidator)
        {
            _productRepository = productRepository;
            _productValidator = productValidator;
        }
        public void AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            
            var validationResult = _productValidator.Validate(product);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            

            var productEntity = new ProductEntity
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity, 
                Description = product.Description,
            };

            _productRepository.AddProduct(productEntity); 

        }
        public List<Product> GetAllProduct()
        {
            var productEntity = _productRepository.GetAllProducts();  
            return productEntity.Select(productEntity => new Product 
                {
                    Id = productEntity.ProductId,
                    Name = productEntity.Name,
                    Price = productEntity.Price,
                    Quantity = productEntity.Quantity,
                    Description = productEntity.Description
                }).ToList();
        }

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
    }
}

using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace PetStore.Data
{
    public class ProductRepository : IProductRepository 
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public void AddProduct(ProductEntity product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                Console.WriteLine("Product saved");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while saving the product: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }
        }
        public ProductEntity GetProductId(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }
        public List<ProductEntity> GetAllProducts()
        {
            return _context.Products.ToList();
        }
    }
}

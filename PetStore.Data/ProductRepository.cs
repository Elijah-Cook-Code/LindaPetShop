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
            _context.Products.Add(product);
            _context.SaveChanges();
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

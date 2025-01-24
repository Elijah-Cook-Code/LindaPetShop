using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public interface IProductRepository
    {
        void AddProduct(ProductEntity product);
        ProductEntity GetProductId(int id);
        List<ProductEntity> GetAllProducts();
    }
}

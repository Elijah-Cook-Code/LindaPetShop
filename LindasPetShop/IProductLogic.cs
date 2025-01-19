using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindasPetShop
{
    public interface IProductLogic
    {
        public void AddProduct(Product product);
        public List<Product> GetAllProduct();
        T GetProductByName<T>(string name) where T : Product;
        List<string> GetOnlyInStockProducts();
        decimal GetTotalPriceOfInventory();
    }
}

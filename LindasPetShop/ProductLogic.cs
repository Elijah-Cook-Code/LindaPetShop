using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindasPetShop
{
    internal class ProductLogic
    {
        private List<Product> _products = new List<Product>();

        Dictionary<string, DogLeash> dogLeashes = new Dictionary<string, DogLeash>();
        Dictionary<string, CatFood> catFoods = new Dictionary<string, CatFood>();
        public ProductLogic()
        {
            _products = new List<Product>();
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
            return dogLeashes[name];
        }
    }
}

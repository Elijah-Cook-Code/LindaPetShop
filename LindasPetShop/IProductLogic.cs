﻿using System;
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
        public Product GetProductById(int id);
       
    }
}

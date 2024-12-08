using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LindasPetShop
{
    internal static class ListExtentions
    {
        public static List<T> InStock<T>(this List<T> list) where T : Product
        {  
            return list.Where(product => product.Quantity > 0).ToList(); 
        }
    }
}

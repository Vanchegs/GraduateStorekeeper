using System;
using Random = UnityEngine.Random;

namespace Internal.Codebase
{
    public class Product
    {
        public ProductsType ProductType { get; private set; }

        public Product() => 
            ProductType = (ProductsType)Enum.GetValues(typeof(ProductsType)).GetValue(Random.Range(0, 18));
    }
}
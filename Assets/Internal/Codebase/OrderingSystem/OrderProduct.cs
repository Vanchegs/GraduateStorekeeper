using System;
using Random = UnityEngine.Random;

namespace Internal.Codebase
{
    public class OrderProduct : Product
    {
        public OrderProduct() => 
            ProductType = (ProductsType)Enum.GetValues(typeof(ProductsType)).GetValue(Random.Range(0, 18));
    }
}
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Internal.Codebase
{
    [CreateAssetMenu(menuName = "Storages/ProductPrices", fileName = "Products", order = 1)]
    public class ProductPrice : ScriptableObject
    {
        [SerializedDictionary("Products Type", "Price")]
        public SerializedDictionary<ProductsType, int> ProductPrices;
    }
}
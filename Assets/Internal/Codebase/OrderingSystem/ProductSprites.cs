using UnityEngine;
using AYellowpaper.SerializedCollections;

namespace Internal.Codebase
{
    [CreateAssetMenu(menuName = "Storages/ProductSprites", fileName = "ProductSprites", order = 0)]
    public class ProductSpritesStorage : ScriptableObject
    {
        [SerializedDictionary("Products Type", "Sprite")]
        public SerializedDictionary<ProductsType, Sprite> ProductSprites;
    }
}
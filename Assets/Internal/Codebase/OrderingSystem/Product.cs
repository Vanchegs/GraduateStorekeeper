using System;
using UnityEngine;

namespace Internal.Codebase
{
    [Serializable]
    public class Product
    {
        public Sprite ProductSprite { get; private set; }
        
        [field: SerializeField] public ProductsType ProductType { get; set; }
        [field: SerializeField] public int Price { get; set; }
        
        public void SetProductSprites(ProductSpritesStorage productSprites) => 
            ProductSprite = productSprites.ProductSprites[ProductType];
    }
}
using System;
using UnityEngine;

namespace Internal.Codebase
{
    [Serializable]
    public class Product
    {
        private Sprite productSprite;
        
        [field: SerializeField] public ProductsType ProductType { get; set; }
    }
}
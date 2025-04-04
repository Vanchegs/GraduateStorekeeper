using System.Collections.Generic;
using Internal.Codebase.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace Internal.Codebase
{
    public class IssueTableProductDisplay : MonoBehaviour
    {
        [SerializeField] private List<Image> images;
        [SerializeField] private OrdersCompiler ordersCompiler;
        [SerializeField] private ProductSpritesStorage spritesStorage;
        
        private List<Product> products;

        private void OnEnable() => 
            GameEventBus.OnOrderCreate += DisplayOrder;

        private void OnDisable() => 
            GameEventBus.OnOrderCreate -= DisplayOrder;

        private void DisplayOrder()
        {
            for (int i = 0; i < ordersCompiler.Order.ProductsList.Length; i++)
                images[i].sprite = spritesStorage.ProductSprites[ordersCompiler.Order.ProductsList[i].ProductType];
        }
    }
}
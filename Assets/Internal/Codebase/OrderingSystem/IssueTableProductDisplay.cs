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

#pragma warning disable CS0414 // Field is assigned but its value is never used
        private bool isInitialized = false;
#pragma warning restore CS0414 // Field is assigned but its value is never used

        private void Awake()
        {
            if (ordersCompiler == null) 
                ordersCompiler = FindObjectOfType<OrdersCompiler>();
        }

        private void OnEnable() => 
            GameEventBus.UpdateOrderDisplay += DisplayOrder;

        private void OnDisable() => 
            GameEventBus.UpdateOrderDisplay -= DisplayOrder;

        public void DisplayOrder()
        {
            if (ordersCompiler.Order.ProductsList == null) return;
            
            var products = ordersCompiler.Order.ProductsList;
                
            for (int i = 0; i < images.Count; i++) 
            { 
                if (i < products.Length && products[i] != null) 
                { 
                    images[i].gameObject.SetActive(true); 
                    products[i].SetProductSprites(spritesStorage); 
                    images[i].sprite = products[i].ProductSprite;
                    images[i].preserveAspect = true;
                }
                else 
                { 
                    images[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
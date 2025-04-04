using System.Collections;
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

        private bool isInitialized = false;

        private void Awake()
        {
            if (ordersCompiler == null)
            {
                ordersCompiler = FindObjectOfType<OrdersCompiler>();
            }
        }

        private void OnEnable()
        {
            Initialize();
            GameEventBus.OnOrderCreate += DisplayOrder;
        }

        private void OnDisable()
        {
            GameEventBus.OnOrderCreate -= DisplayOrder;
        }

        private void Initialize()
        {
            if (isInitialized) return;
            
            if (ordersCompiler == null)
            {
                Debug.LogError("OrdersCompiler не найден!");
                return;
            }

            if (spritesStorage == null)
            {
                Debug.LogError("SpritesStorage не назначен!");
                return;
            }

            isInitialized = true;
        }

        private void DisplayOrder()
        {
            if (!isInitialized) Initialize();

            StartCoroutine(DisplayOrderWithDelay());
        }

        private IEnumerator DisplayOrderWithDelay()
        {
            // Ждём один кадр для гарантии инициализации
            yield return null;
            
            var products = ordersCompiler.Order.ProductsList;
            if (products == null || products.Length == 0)
            {
                Debug.LogError("Список продуктов пуст!");
                yield break;
            }

            for (int i = 0; i < images.Count; i++)
            {
                if (i < products.Length && products[i] != null)
                {
                    images[i].gameObject.SetActive(true);
                    images[i].sprite = spritesStorage.ProductSprites[products[i].ProductType];
                }
                else
                {
                    images[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
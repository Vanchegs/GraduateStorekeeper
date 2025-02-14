using UnityEngine;
using System.Collections.Generic;

namespace Internal.Codebase
{
    public class Inventory
    {
        public List<Product> inventoryList;
        private const int maxInventorySize = 2;

        public Inventory() => 
            inventoryList = new List<Product>();

        public void AddProduct(Product item)
        {
            if (inventoryList.Count < maxInventorySize)
            {
                inventoryList.Add(item);
                Debug.Log(item + " добавлен в инвентарь.");
            }
            else
            { 
                Debug.Log("Инвентарь полон! Нельзя добавить " + item + ".");
            }
        }
            
        public void RemoveProduct(Product item)
        {
            if (inventoryList.Contains(item))
            {
                inventoryList.Remove(item);
                Debug.Log(item + " удален из инвентаря.");
            }
            else
            {
                Debug.Log(item + " не найден в инвентаре.");
            }
        }

        public void RemoveAllProducts() => 
            inventoryList.Clear();

        public void DisplayInventory()
        {
            if (inventoryList.Count == 0)
            { 
                Debug.Log("Инвентарь пуст.");
            }
            else
            {
                Debug.Log("Содержимое инвентаря:");
                foreach (Product item in inventoryList)
                { 
                    Debug.Log("- " + item.ProductType); 
                }
            }
        }
    }
}
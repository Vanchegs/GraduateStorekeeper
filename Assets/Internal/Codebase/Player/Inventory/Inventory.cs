using UnityEngine;
using System.Collections.Generic;

namespace Internal.Codebase
{
    public class Inventory
    {
        private List<Product> inventoryList;
        private const int maxInventorySize = 2;

        public Inventory() => 
            inventoryList = new List<Product>();

        public void TakeProduct(Product item)
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
            
        public void DiscardProduct(Product item)
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

        public void IssueTheProduct() => 
            inventoryList.Clear();

        public bool CheckInventoryFull()
        {
            if (inventoryList.Count == maxInventorySize)
                return true;

            return false;
        }

        public List<Product> GetInventory() => 
            inventoryList;

        public void ChangeInventory(List<Product> changedInventory) => 
            inventoryList = changedInventory;

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
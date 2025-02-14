using UnityEngine;
using System.Collections.Generic;

namespace Internal.Codebase.Inventory
{
    public class Inventory
    {
        public List<Product> inventory;
        private const int maxInventorySize = 2;

        public Inventory() => 
            inventory = new List<Product>();

        private void AddItem(Product item)
        {
            if (inventory.Count < maxInventorySize)
            {
                inventory.Add(item);
                Debug.Log(item + " добавлен в инвентарь.");
            }
            else
            { 
                Debug.Log("Инвентарь полон! Нельзя добавить " + item + ".");
            }
        }
            
        private void RemoveItem(Product item)
        {
            if (inventory.Contains(item))
            {
                inventory.Remove(item);
                Debug.Log(item + " удален из инвентаря.");
            }
            else
            {
                Debug.Log(item + " не найден в инвентаре.");
            }
        }

        private void RemoveAllItems() => 
            inventory.Clear();

        private void DisplayInventory()
        {
            if (inventory.Count == 0)
            { 
                Debug.Log("Инвентарь пуст.");
            }
            else
            {
                Debug.Log("Содержимое инвентаря:");
                foreach (Product item in inventory)
                { 
                    Debug.Log("- " + item.ProductType); 
                }
            }
        }
    }
}
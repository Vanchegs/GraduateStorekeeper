using UnityEngine;
using System.Collections.Generic;
using Internal.Codebase.Infrastructure;

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
                GameEventBus.UpdateInventoryDisplay.Invoke();
            }
        }
            
        public void DiscardProduct(Product item)
        {
            if (inventoryList.Contains(item))
            {
                inventoryList.Remove(item);
                GameEventBus.UpdateInventoryDisplay.Invoke();
            }
        }

        public void IssueTheProduct()
        {
            inventoryList.Clear();
            GameEventBus.UpdateInventoryDisplay.Invoke();
        }

        public bool CheckInventoryFull()
        {
            if (inventoryList.Count == maxInventorySize)
                return true;

            return false;
        }

        public List<Product> GetInventory() => 
            inventoryList;

        public void ChangeInventory(List<Product> changedInventory)
        {
            inventoryList = changedInventory;
            GameEventBus.UpdateInventoryDisplay.Invoke();
        }
    }
}
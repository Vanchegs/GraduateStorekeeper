using System.Collections.Generic;
using System.Linq;
using Internal.Codebase;
using Internal.Codebase.Infrastructure;
using UnityEngine;

public class InventoryChecker : MonoBehaviour
{
    [SerializeField] private OrdersCompiler ordersCompiler;

    private void CheckInventory(Inventory playerInventory)
    {
        var inventory = playerInventory.GetInventory();
        
        if (ordersCompiler.Order == null)
        {
            Debug.Log("Заказа еще нет");
            return;
        }

        var orderProducts = ordersCompiler.Order.ProductsList.ToList();

        RemoveMatchingItems(orderProducts, inventory);
        
        playerInventory.ChangeInventory(inventory);
        ordersCompiler.Order.ChangeOrder(orderProducts);
        
        for (int i = 0; i < orderProducts.Count; i++)
            Debug.Log("Оставшиеся элементы в заказах: " + string.Join(", ", orderProducts[i].ProductType));
        
        for (int i = 0; i < inventory.Count; i++)
            Debug.Log("Оставшиеся элементы в инвентаре: " + string.Join(", ", inventory[i].ProductType));
    }

    private void RemoveMatchingItems(List<OrderProduct> orderProducts, List<Product> inventory)
    {
        List<OrderProduct> itemsToRemoveFromOrders = new List<OrderProduct>();
        List<Product> itemsToRemoveFromInventory = new List<Product>();

        foreach (var inventoryItem in inventory)
        {
            var matchingOrderProduct = orderProducts.FirstOrDefault(op => op.ProductType == inventoryItem.ProductType);
            if (matchingOrderProduct != null)
            {
                itemsToRemoveFromOrders.Add(matchingOrderProduct);
                itemsToRemoveFromInventory.Add(inventoryItem);
            }
        }
        
        foreach (var item in itemsToRemoveFromOrders)
        {
            orderProducts.Remove(item);
        }

        foreach (var item in itemsToRemoveFromInventory)
        {
            inventory.Remove(item);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<PlayerComponent>();
            if (player == null) return;
            CheckInventory(player.Inventory);
            GameEventBus.UpdateOrderDisplay.Invoke();
        }
    }
}

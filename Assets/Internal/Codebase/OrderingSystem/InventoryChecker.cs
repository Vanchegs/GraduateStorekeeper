using System.Collections.Generic;
using System.Linq;
using Internal.Codebase;
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
        
        for (int i = 0; i < orderProducts.Count; i++)
            Debug.Log("Оставшиеся элементы в заказах: " + string.Join(", ", orderProducts[i].ProductType));
        
        for (int i = 0; i < inventory.Count; i++)
            Debug.Log("Оставшиеся элементы в инвентаре: " + string.Join(", ", inventory[i].ProductType));
    }

    private void RemoveMatchingItems(List<OrderProduct> orderProducts, List<Product> inventory)
    {
        List<Product> itemsToRemoveFromOrders = new List<Product>();
        List<Product> itemsToRemoveFromInventory = new List<Product>();

        foreach (var item in inventory)
        {
            if (orderProducts.Contains(item))
            {
                itemsToRemoveFromOrders.Add(item);
                itemsToRemoveFromInventory.Add(item);
            }
        }
        
        foreach (var product in itemsToRemoveFromOrders)
        {
            var item = (OrderProduct)product;
            orderProducts.Remove(item);
        }

        foreach (var item in itemsToRemoveFromInventory) 
            inventory.Remove(item);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<PlayerComponent>();
            if (player == null) return;
            CheckInventory(player.Inventory);
        }
    }
}

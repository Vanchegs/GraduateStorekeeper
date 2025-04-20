using System.Collections.Generic;
using System.Linq;
using Internal.Codebase;
using Internal.Codebase.Infrastructure;
using UnityEngine;

public class InventoryChecker : MonoBehaviour
{
    [SerializeField] private OrdersCompiler ordersCompiler;

    private void CheckInventory(Inventory playerInventory, Wallet wallet)
    {
        var inventory = playerInventory.GetInventory();
        
        if (ordersCompiler.Order == null)
        {
            Debug.Log("Заказа еще нет");
            return;
        }

        var orderProducts = ordersCompiler.Order.ProductsList.ToList();

        if (orderProducts.Count == 0)
        {
            ordersCompiler.OrderComplete();
            wallet.ChargeToWallet(ordersCompiler.Order.OrderPrice);
            return;
        }

        RemoveMatchingItems(orderProducts, inventory);

        playerInventory.ChangeInventory(inventory);
        ordersCompiler.Order.ChangeOrder(orderProducts);
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
            CheckInventory(player.Inventory, player.Wallet); 
            if (ordersCompiler.Order == null)
                return;
            GameEventBus.UpdateOrderDisplay.Invoke();
        }
    }
}

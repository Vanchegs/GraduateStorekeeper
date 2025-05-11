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
        
        RemoveMatchingItems(orderProducts, inventory);
        
        
        if (orderProducts.Count == 0)
        {
            ordersCompiler.OrderComplete();
            wallet.ChargeToWallet(ordersCompiler.Order.OrderPrice);
        }
        
        playerInventory.ChangeInventory(inventory);
        ordersCompiler.Order.ChangeOrder(orderProducts);
    }

    private void RemoveMatchingItems(List<OrderProduct> orderProducts, List<Product> inventory)
    {
        var remainingOrderProducts = new List<OrderProduct>(orderProducts);
        var remainingInventory = new List<Product>(inventory);
        
        orderProducts.Clear();
        inventory.Clear();

        foreach (var orderProduct in remainingOrderProducts)
        {
            var inventoryItem = remainingInventory.FirstOrDefault(p => p.ProductType == orderProduct.ProductType);

            if (inventoryItem != null)
                remainingInventory.Remove(inventoryItem);
            else
                orderProducts.Add(orderProduct);
        }
        
        inventory.AddRange(remainingInventory);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<PlayerComponent>();
            CheckInventory(player.Inventory, player.Wallet);
            if (ordersCompiler.Order == null) 
                return;
            GameEventBus.UpdateOrderDisplay.Invoke();
        }
    }
}

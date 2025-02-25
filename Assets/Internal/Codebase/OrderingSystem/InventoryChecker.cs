using System.Linq;
using Internal.Codebase;
using UnityEngine;

public class InventoryChecker : MonoBehaviour
{
    private OrdersCompiler ordersCompiler;

    private void Start() => 
        ordersCompiler = GetComponent<OrdersCompiler>();

    private void CheckInventory(Inventory playerInventory)
    {
        if (playerInventory.CheckInventoryFull())
        {
            var inventory = playerInventory.GetInventory();
            
            bool areEqual = ordersCompiler.Order.ProductsList.Length == inventory.Count && 
                            ordersCompiler.Order.ProductsList.GroupBy(x => x)
                                .All(g => inventory.Count(x => x == g.Key) == g.Count());
            
            Debug.Log(areEqual);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<PlayerComponent>();
            
            CheckInventory(player.Inventory);
        }
    }
}

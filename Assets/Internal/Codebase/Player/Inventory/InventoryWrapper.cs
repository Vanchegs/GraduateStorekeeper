using UnityEngine;
using Internal.Codebase;

public class InventoryWrapper : MonoBehaviour
{
    private Inventory inventory;

    private void Start() => 
        inventory = new Inventory();

    private void TakeProduct()
    {
        // inventory.AddProduct();
    }

    private void IssueTheProduct()
    {
        inventory.RemoveAllProducts();
    }
}

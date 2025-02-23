using UnityEngine;

namespace Internal.Codebase
{
    public class IssuePoint : MonoBehaviour
    {
        [SerializeField] private Product product;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                var player = other.GetComponent<PlayerComponent>();

                if (player != null) 
                    player.Inventory.TakeProduct(product);

                player.Inventory.DisplayInventory();
            }
        }
    }
}
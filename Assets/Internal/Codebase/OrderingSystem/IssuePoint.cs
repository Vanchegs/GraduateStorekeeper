using UnityEngine;

namespace Internal.Codebase
{
    public class IssuePoint : MonoBehaviour
    {
        [field: SerializeField] public Product Product { get; private set; }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                var player = other.GetComponent<PlayerComponent>();

                if (player != null) 
                    player.Inventory.TakeProduct(Product);

                player.Inventory.DisplayInventory();
            }
        }
    }
}
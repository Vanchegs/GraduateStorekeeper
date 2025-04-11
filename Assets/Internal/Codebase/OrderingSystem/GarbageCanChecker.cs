using UnityEngine;

namespace Internal.Codebase
{
    public class GarbageCanChecker : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                var player = other.GetComponent<PlayerComponent>();
                if (player == null) return;
                player.Inventory.IssueTheProduct();
            }
        }
    }
}
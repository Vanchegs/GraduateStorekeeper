using UnityEngine;

namespace Internal.Codebase
{
    public class PlayerComponent : MonoBehaviour
    {
        [SerializeField] private Mover mover;
        
        private Inventory inventory;

        private void Start()
        {
            mover = new Mover();
            inventory = new Inventory();
        }
    }
}
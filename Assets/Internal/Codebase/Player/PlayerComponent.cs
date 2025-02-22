using UnityEngine;

namespace Internal.Codebase
{
    public class PlayerComponent : MonoBehaviour
    {
        [SerializeField] private Mover mover;
        
        public Inventory Inventory { get; private set; }

        private void Start() => 
            Inventory = new Inventory();

        private void FixedUpdate() => 
            mover.MovementControl();
    }
}
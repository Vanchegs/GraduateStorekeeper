using Internal.Codebase.Infrastructure;
using UnityEngine;

namespace Internal.Codebase
{
    public class PlayerComponent : MonoBehaviour
    {
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private Animator animator;

        private SpriteRenderer sprite;
        
        [field: SerializeField] public Mover Mover { get; private set; }

        public Inventory Inventory { get; private set; }
        public Wallet Wallet { get; private set; } = new();

        private void Start()
        {
            sprite = GetComponent<SpriteRenderer>();
            
            Inventory = new Inventory();
            
            sprite.sprite = playerConfig.playerSprite;
        }

        private void FixedUpdate() => 
            Mover.MovementControl(sprite, animator);

        public void ClearInventory() => 
            Inventory.ClearInventory();
    }
}
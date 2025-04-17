using UnityEngine;

namespace Internal.Codebase
{
    public class PlayerComponent : MonoBehaviour
    {
        [SerializeField] private Mover mover;
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private Animator animator;
        
        private SpriteRenderer sprite;
            
        public Inventory Inventory { get; private set; }
        public Wallet Wallet { get; private set; } = new();
        
        private void Start()
        {
            sprite = GetComponent<SpriteRenderer>();
            
            Inventory = new Inventory();
            
            sprite.sprite = playerConfig.playerSprite;
        }

        private void FixedUpdate() => 
            mover.MovementControl(sprite, animator);
    }
}
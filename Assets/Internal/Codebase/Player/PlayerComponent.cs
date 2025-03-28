using UnityEngine;

namespace Internal.Codebase
{
    public class PlayerComponent : MonoBehaviour
    {
        [SerializeField] private Mover mover;
        [SerializeField] private PlayerConfig playerConfig;
        
        private SpriteRenderer sprite; 
            
        public Inventory Inventory { get; private set; }

        private void Start()
        {
            sprite = GetComponent<SpriteRenderer>();
            
            Inventory = new Inventory();
            
            sprite.sprite = playerConfig.playerSprite;
        }

        private void FixedUpdate() => 
            mover.MovementControl();
    }
}
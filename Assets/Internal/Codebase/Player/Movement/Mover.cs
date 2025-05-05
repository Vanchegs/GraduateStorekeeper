using System;
using UnityEngine;

namespace Internal.Codebase
{
    [Serializable]
    public class Mover
    {
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private Rigidbody2D playerRb;

        [field: SerializeField] public Joystick Joystick { get; private set; }
        
        public StaminaSystem StaminaSystem { get; private set; } = new();

        public void MovementControl(SpriteRenderer playerSprite, Animator animator)
        {
            float currentSpeed = GetCurrentSpeed();
            
            playerRb.velocity = new Vector2(Joystick.Horizontal * currentSpeed,
                Joystick.Vertical * currentSpeed);

            playerSprite.flipX = Joystick.Direction.x switch
            {
                > 0 => false,
                < 0 => true,
                _ => playerSprite.flipX
            };

            if (Joystick.Direction != Vector2.zero)
            {
                animator.SetBool("IsRun", true);
                StaminaSystem.ConsumeStamina(Time.deltaTime);
            }
            else
            {
                animator.SetBool("IsRun", false);
            }
        }

        private float GetCurrentSpeed()
        {
            return StaminaSystem.CurrentStaminaPercent < 30f
                ? playerConfig.Speed / 1.5f 
                : playerConfig.Speed;
        }
    }
}

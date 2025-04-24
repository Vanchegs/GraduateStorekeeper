using System;
using UnityEngine;

namespace Internal.Codebase
{
    [Serializable]
    public class Mover
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private Rigidbody2D playerRb;
        
        public StaminaSystem StaminaSystem { get; private set; } = new();

        public void MovementControl(SpriteRenderer playerSprite, Animator animator)
        {
            float currentSpeed = GetCurrentSpeed();
            
            playerRb.velocity = new Vector2(joystick.Horizontal * currentSpeed,
                joystick.Vertical * currentSpeed);

            playerSprite.flipX = joystick.Direction.x switch
            {
                > 0 => false,
                < 0 => true,
                _ => playerSprite.flipX
            };

            if (joystick.Direction != Vector2.zero)
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

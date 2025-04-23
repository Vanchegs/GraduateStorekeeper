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
        
        public StaminaSystem staminaSystem { get; private set; } = new();

        public void MovementControl(SpriteRenderer playerSprite, Animator animator)
        {
            float currentSpeed = GetCurrentSpeed();
            
            playerRb.velocity = new Vector2(joystick.Horizontal * currentSpeed,
                joystick.Vertical * currentSpeed);
            
            playerSprite.flipX = joystick.Direction.x < 0;
            
            if (joystick.Direction != Vector2.zero)
            {
                animator.SetBool("IsRun", true);
                staminaSystem.ConsumeStamina(Time.deltaTime);
            }
            else
            {
                animator.SetBool("IsRun", false);
            }
        }

        private float GetCurrentSpeed()
        {
            return staminaSystem.CurrentStaminaPercent < 30f
                ? playerConfig.Speed / 1.5f 
                : playerConfig.Speed;
        }
    }
}

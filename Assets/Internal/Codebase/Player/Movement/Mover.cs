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

        public void MovementControl(SpriteRenderer playerSprite, Animator animator)
        {
            playerRb.velocity = new Vector2(joystick.Horizontal * playerConfig.Speed,
                joystick.Vertical * playerConfig.Speed);
            
            playerSprite.flipX = joystick.Direction.x < 0;
            
            if (joystick.Direction != Vector2.zero)
                animator.SetBool("IsRun", true);
            else
                animator.SetBool("IsRun", false);
        }
    }
}

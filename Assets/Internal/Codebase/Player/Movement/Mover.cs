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

        public void MovementControl() => 
            playerRb.velocity = new Vector2(joystick.Horizontal * playerConfig.Speed, joystick.Vertical * playerConfig.Speed);
    }
}

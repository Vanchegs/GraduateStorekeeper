using UnityEngine;

namespace Internal.Codebase
{
    public class Move : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        
        private float speed = 3;
        private Rigidbody2D playerRb;
    
        void Start()
        {
            playerRb = GetComponent<Rigidbody2D>();

            if (joystick != null) 
                Debug.Log("No joystick");
        }

        void FixedUpdate() => 
            MovementControl();

        private void MovementControl() => 
            playerRb.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);
    }
}

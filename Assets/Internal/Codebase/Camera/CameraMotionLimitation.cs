using UnityEngine;

namespace Internal.Codebase.Camera
{
    public class CameraMotionLimitation : MonoBehaviour
    {
        [SerializeField] private float minValueX, maxValueX; 
        [SerializeField] private float minValueY, maxValueY;
        [SerializeField] private Transform cameraTransform; 

        void Update()
        {
            float clampedX = Mathf.Clamp(cameraTransform.position.x, minValueX, maxValueX);
            
            float clampedY = Mathf.Clamp(cameraTransform.position.y, minValueY, maxValueY);
            
            cameraTransform.position = new Vector2(clampedX, clampedY);
        }
    }
}

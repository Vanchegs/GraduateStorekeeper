using UnityEngine;

namespace Internal.Codebase
{
    public class CameraMotionLimitation : MonoBehaviour
    {
        [SerializeField] private float minValueX, maxValueX; 
        [SerializeField] private float minValueY, maxValueY;
        
        private Transform cameraTransform;

        private void Start() => 
            cameraTransform = GetComponent<Transform>();

        private void LateUpdate() => 
            CheckCameraLimit();

        private void CheckCameraLimit()
        {
            float clampedX = Mathf.Clamp(cameraTransform.position.x, minValueX, maxValueX);

            float clampedY = Mathf.Clamp(cameraTransform.position.y, minValueY, maxValueY);

            cameraTransform.position = new Vector3(clampedX, clampedY, cameraTransform.position.z);
        }
    }
}

using UnityEngine;

namespace Internal.Codebase.Camera
{
    public class CameraTracking : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Bounds mapBounds;

        private Transform cameraTransform;

        private void Start() => 
            cameraTransform = transform;

        private void LateUpdate()
        {
            if (transform.position.x > mapBounds.min.x && transform.position.x < mapBounds.max.x)
            {
                if (transform.position.y > mapBounds.min.y && transform.position.y < mapBounds.max.y)
                {
                    Vector2 newPosition = player.position;
                    
                    cameraTransform.position = new Vector3(newPosition.x, newPosition.y);
                }
            }
        }
    }
}

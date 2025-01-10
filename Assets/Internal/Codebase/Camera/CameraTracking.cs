using UnityEngine;

namespace Internal.Codebase.Camera
{
    public class CameraTracking : MonoBehaviour
    {
        [SerializeField] private Transform player;

        void LateUpdate()
        {
            Vector3 temp = transform.position;

            temp.x = player.position.x;
            temp.y = player.position.y;

            transform.position = temp;
        }
    }
}

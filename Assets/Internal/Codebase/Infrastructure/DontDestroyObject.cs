using UnityEngine;

namespace Internal.Codebase.Infrastructure
{
    public class DontDestroyObject : MonoBehaviour
    {
        private void Awake()
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestroyObject");

            if (objs.Length > 1)
                Destroy(gameObject);
            else
            {
                DontDestroyOnLoad(gameObject);
                gameObject.tag = "DontDestroyObject";
            }
        }
    }
}
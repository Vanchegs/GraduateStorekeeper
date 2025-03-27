using UnityEngine;

namespace Internal.Codebase
{
    [CreateAssetMenu(menuName = "Configs/PlayerConfig", fileName = "PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        public float Speed;
        public Sprite playerSprite;
    }
}

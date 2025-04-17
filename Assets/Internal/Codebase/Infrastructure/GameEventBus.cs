using System;
using UnityEngine;

namespace Internal.Codebase.Infrastructure
{
    public class GameEventBus : MonoBehaviour
    {
        public static Action UpdateOrderDisplay;
        public static Action UpdateInventoryDisplay;
        public static Action UpdateWalletUI;
    }
}
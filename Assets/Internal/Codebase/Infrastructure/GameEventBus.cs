using System;
using UnityEngine;

namespace Internal.Codebase.Infrastructure
{
    public class GameEventBus : MonoBehaviour
    {
        public static Action OnOrderCreate;
    }
}
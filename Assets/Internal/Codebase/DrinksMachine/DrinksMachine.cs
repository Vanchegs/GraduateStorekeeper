using Internal.Codebase;
using UnityEngine;

public class DrinksMachine : MonoBehaviour
{
    [SerializeField] private PlayerComponent player;

    private int refillAmount = 50;
    
    private void StaminaRefill() => 
        player.Mover.staminaSystem.RecoverStamina(refillAmount);
}

using Internal.Codebase;
using UnityEngine;

public class DrinksMachine : MonoBehaviour
{
    private int refillAmount = 50;
    private int drinkPrice = 80;
    
    private void StaminaRefill(PlayerComponent player)
    {
        if (player.Wallet.WriteOffMoney(drinkPrice) > 0) 
            player.Mover.StaminaSystem.RecoverStamina(refillAmount);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<PlayerComponent>();
            
            StaminaRefill(player);
        }
    }
}

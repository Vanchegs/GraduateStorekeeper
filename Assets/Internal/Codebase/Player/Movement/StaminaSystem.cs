using UnityEngine;
using UnityEngine.Events;

namespace Internal.Codebase
{
    public class StaminaSystem
    {
        private float maxStamina = 100f;
        private float consumeRate = 1.5f;
    
        public UnityEvent<float> OnStaminaChanged = new();
    
        private float currentStamina;
    
        public float CurrentStamina => currentStamina;
        public float MaxStamina => maxStamina;
        public float CurrentStaminaPercent => (currentStamina / maxStamina) * 100f;

        public StaminaSystem()
        {
            currentStamina = maxStamina;
            OnStaminaChanged?.Invoke(currentStamina);
        }

        public void ConsumeStamina(float amount)
        {
            currentStamina -= consumeRate * amount;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
            OnStaminaChanged?.Invoke(currentStamina);
        }

        public void ResetStamina()
        {
            currentStamina = maxStamina;
            OnStaminaChanged?.Invoke(currentStamina);
        }

        public void RecoverStamina(float amount)
        {
            currentStamina += amount;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
            OnStaminaChanged?.Invoke(currentStamina);
        }
    }
}
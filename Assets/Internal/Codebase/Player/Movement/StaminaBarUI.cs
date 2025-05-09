using UnityEngine;
using UnityEngine.UI;

namespace Internal.Codebase
{
    public class StaminaBarUI : MonoBehaviour
    {
        [SerializeField] private Slider staminaSlider;
        [SerializeField] private Image fillImage;
        [SerializeField] private Color fullStaminaColor = Color.green;
        [SerializeField] private Color lowStaminaColor = Color.red;
        [SerializeField] private PlayerComponent player;
    
        private StaminaSystem staminaSystem;

        private void Start()
        {
            staminaSystem = player.Mover.StaminaSystem;

            staminaSystem.OnStaminaChanged.AddListener(UpdateStaminaUI);
            staminaSlider.maxValue = staminaSystem.MaxStamina;
            UpdateStaminaUI(staminaSystem.CurrentStamina);
        }

        private void UpdateStaminaUI(float currentStamina)
        {
            if (staminaSlider == null || fillImage == null) return;
        
            staminaSlider.value = currentStamina;
            fillImage.color = Color.Lerp(
                lowStaminaColor, 
                fullStaminaColor, 
                currentStamina / staminaSystem.MaxStamina
            );
        }

        private void OnDestroy()
        {
            if (staminaSystem != null && staminaSystem.OnStaminaChanged != null)
                staminaSystem.OnStaminaChanged.RemoveListener(UpdateStaminaUI);
        }
    }
}
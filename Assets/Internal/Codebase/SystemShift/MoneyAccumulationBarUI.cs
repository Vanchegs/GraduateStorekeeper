using UnityEngine;
using UnityEngine.UI;

namespace Internal.Codebase.SystemShift
{
    public class MoneyAccumulationBarUI : MonoBehaviour
    {
        private const int TicketPrice = 100000;
        
        [SerializeField] private Slider moneySlider;
        [SerializeField] private Image fillImage;
        [SerializeField] private PlayerComponent player;
    
        private Wallet wallet;

        private void Start()
        {
            wallet = player.Wallet;

            moneySlider.maxValue = TicketPrice;
            UpdateUIBar(wallet.PlayerBalance);
        }

        private void UpdateUIBar(float currentBalance)
        {
            if (moneySlider == null || fillImage == null) return;
        
            moneySlider.value = currentBalance;
        }
    }
}
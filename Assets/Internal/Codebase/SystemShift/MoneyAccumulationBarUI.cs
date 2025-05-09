using Internal.Codebase.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace Internal.Codebase
{
    public class MoneyAccumulationBarUI : MonoBehaviour
    {
        private const int TicketPrice = 100000;
        
        [SerializeField] private Slider moneySlider;
        [SerializeField] private Image fillImage;
        [SerializeField] private PlayerComponent player;
    
        private Wallet wallet;

        private void OnEnable() => 
            GameEventBus.EndOfShift += UpdateUIBar;

        private void OnDisable() => 
            GameEventBus.EndOfShift -= UpdateUIBar;

        private void Start()
        {
            wallet = player.Wallet;

            moneySlider.maxValue = TicketPrice;
        }

        private void UpdateUIBar()
        {
            if (moneySlider == null || fillImage == null) return;
        
            moneySlider.value = wallet.PlayerBalance;
        }
    }
}
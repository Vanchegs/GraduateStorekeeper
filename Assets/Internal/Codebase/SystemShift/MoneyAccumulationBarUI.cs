using Internal.Codebase.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace Internal.Codebase
{
    public class MoneyAccumulationBarUI : MonoBehaviour
    {
        private const int TicketPrice = 50000;
        
        [SerializeField] private Slider moneySlider;
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
            
            UpdateUIBar();
        }

        private void UpdateUIBar() => 
            moneySlider.value = wallet.PlayerBalance;
    }
}
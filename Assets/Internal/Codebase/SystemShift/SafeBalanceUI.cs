using TMPro;
using UnityEngine;


namespace Internal.Codebase
{
    public class SafeBalanceUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text safeBalanceText;
        [SerializeField] private PlayerComponent playerComponent;
        [SerializeField] private GameObject endGameButton;
        [SerializeField] private MoneyAccumulationBarUI moneyBar;

        public int SafeBalance { get; private set; }
        
        public void UpdateSafeBalance()
        {
            SafeBalance = playerComponent.Wallet.PlayerBalance;
            
            safeBalanceText.text = SafeBalance.ToString();

            if (SafeBalance >= moneyBar.TicketPrice) 
                endGameButton.SetActive(true);
        }
    }
}


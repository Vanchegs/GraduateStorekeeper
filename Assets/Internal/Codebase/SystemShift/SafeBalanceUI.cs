using TMPro;
using UnityEngine;


namespace Internal.Codebase
{
    public class SafeBalanceUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text safeBalanceText;
        [SerializeField] private PlayerComponent playerComponent;

        public void UpdateSafeBalance() => 
            safeBalanceText.text = playerComponent.Wallet.PlayerBalance.ToString();
    }
}


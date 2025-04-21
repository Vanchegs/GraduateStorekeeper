using Internal.Codebase.Infrastructure;
using TMPro;
using UnityEngine;

namespace Internal.Codebase
{
    public class WalletUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text walletText;
        [SerializeField] private PlayerComponent player;

        private void Start()
        {
            if (player.Wallet == null)
            {
                Debug.LogError("У Player нет Wallet!");
                return;
            }

            walletText.text = player.Wallet.PlayerWallet.ToString();
        }

        private void OnEnable() => 
            GameEventBus.UpdateWalletUI += UpdateWallet;

        private void OnDisable() => 
            GameEventBus.UpdateWalletUI -= UpdateWallet;

        private void UpdateWallet() => 
            walletText.text = player.Wallet.PlayerWallet.ToString();
    }
}
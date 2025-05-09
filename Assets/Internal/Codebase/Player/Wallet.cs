using Internal.Codebase.Infrastructure;

namespace Internal.Codebase
{
    public class Wallet
    {
        public int PlayerBalance { get; private set; }
        
        public void ChargeToWallet(int value)
        {
            PlayerBalance += value;
            
            GameEventBus.UpdateWalletUI?.Invoke();
        }

        public int WriteOffMoney(int value)
        {
            PlayerBalance -= value;
            
            if (PlayerBalance <= 0) 
                PlayerBalance = 0;
            
            GameEventBus.UpdateWalletUI?.Invoke();

            return PlayerBalance;
        }

        public void SetSavedBalance(int saveDataPlayerBalance) => 
            PlayerBalance = saveDataPlayerBalance;
    }
}
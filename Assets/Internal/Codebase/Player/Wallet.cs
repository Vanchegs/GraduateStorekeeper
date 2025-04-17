using Internal.Codebase.Infrastructure;

namespace Internal.Codebase
{
    public class Wallet
    {
        public int PlayerWallet { get; private set; }
        
        public void ChargeToWallet(int value)
        {
            PlayerWallet += value;
            
            GameEventBus.UpdateWalletUI?.Invoke();
        }

        public void WriteOffMoney(int value)
        {
            PlayerWallet -= value;
            
            if (PlayerWallet > 0) 
                PlayerWallet = 0;
            
            GameEventBus.UpdateWalletUI?.Invoke();
        }
    }
}
using UnityEngine;
namespace Player
{

    class CanPurchaseClass : MonoBehaviour, ICanPurchaseClass
    {
        
        CoinSystem coinSystem;
        IChangeCoinAmounts changeCoinAmount;

        private void Awake()
        {
            coinSystem = GetComponent<CoinSystem>();
            changeCoinAmount = GetComponent<IChangeCoinAmounts>();
        }
        public bool CanPurchase(int price)
        {
            if (coinSystem.CurrentCoin >= price)
            {
                
                return true;//iobg
            }
            else
            {
                return false;
            }
        }
    }
}
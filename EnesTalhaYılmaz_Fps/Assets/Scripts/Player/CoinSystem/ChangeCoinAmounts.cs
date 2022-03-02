using UnityEngine;
namespace Player
{
    public enum Operator{
        Inc,Dec
    }

    

    public class ChangeCoinAmounts : MonoBehaviour, IChangeCoinAmounts
    {
        CoinSystem coinSystem;
        private void Awake()
        {
            coinSystem = GetComponent<CoinSystem>();
        }

        public void ChangeCoinAmount(int Amount, Operator operatorEnum)
        {
            switch (operatorEnum)
            {
                case Operator.Dec:
                    coinSystem.CurrentCoin -= Amount;
                    break;
                case Operator.Inc:
                    coinSystem.CurrentCoin += Amount;
                    break;
            }
        }
    }
}
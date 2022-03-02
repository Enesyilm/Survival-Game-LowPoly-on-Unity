using UnityEngine;
using Player;

public interface IChangeCoinAmounts
    {
        void ChangeCoinAmount(int Amount, Operator operatorEnum);
    }
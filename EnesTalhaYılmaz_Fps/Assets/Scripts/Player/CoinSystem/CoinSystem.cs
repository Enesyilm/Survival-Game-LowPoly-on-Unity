using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player{
    
public class CoinSystem : MonoBehaviour
{
    [SerializeField] int currentCoin;
    // Player.ChangeCoinAmounts changeCoinAmount;
    // Player.CanPurchaseClass CanPurchaseClass;
    
    public int CurrentCoin { get => currentCoin; set => currentCoin = value; }
    private void Awake() {
        
    }
}
}

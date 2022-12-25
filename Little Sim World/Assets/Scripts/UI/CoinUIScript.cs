using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinUIScript : MonoBehaviour
{
    public TMP_Text cointText;
    private int coinCount = 0;
    public int _coinCount { get {return coinCount; } set { coinCount = value; } }



    public void UpdateUiCoins(int value)
    {
        coinCount += value;
        cointText.text = coinCount.ToString(); ;
    }
}

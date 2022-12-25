using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManger : MonoBehaviour
{
    public static LevelManger Instance;

    private int CoinCount;
    public int coinCount { get { return CoinCount; } set { CoinCount = value; } }


    private void Awake()
    {
        Instance = this;
        CoinCount = 120;
        
    }
    private void Start()
    {
        MainCanvasUIScript.Instance.coinUIScript.UpdateUiCoins(coinCount);
    }
}

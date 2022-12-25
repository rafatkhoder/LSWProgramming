using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PriceItemUIScript : MonoBehaviour
{
    public TMP_Text price;
    private void Awake()
    {
        gameObject.SetActive(true);
    }
    public void GetPrice(int price)
    {
        gameObject.SetActive(price > 0);
        this.price.text = price.ToString();
    }

  
}

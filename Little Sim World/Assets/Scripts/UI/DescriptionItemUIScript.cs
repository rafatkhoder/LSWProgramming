using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DescriptionItemUIScript : MonoBehaviour
{
    public PriceItemUIScript priceItemUIScript;
    public ButtonItemUIScript buttonItemUIScript;
    public Image image;
    public TMP_Text nameUiText;
    public string name;
    

    public void cellData( Sprite image, string name ,int price)
    {
        this.image.sprite = image;
        this.name = name;
        this.nameUiText.text = name;
        priceItemUIScript.GetPrice(price);
    }
    public void RestDescription()
    {
        cellData(ScriptbleObjectData.Instance.defaultSpriteDescrition, "",0);
    }

   


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCommpontManger : MonoBehaviour
{
    public Sprite sprit;
    public string name;
    public int count;
    public int price;

    private bool equiptObject = false;
    public bool _equiptObject
    {
        get { return equiptObject; }
        set { equiptObject = value; }
    }
    private void Awake()
    {
        name = this.tag;
    }
   
    private void OnDisable()
    {
        if (name == GameStrings.Axe) { equiptObject = false;  }
    }
    private void OnEnable()
    {
        if (name == GameStrings.Axe) { equiptObject = true;  }
    }
  
}

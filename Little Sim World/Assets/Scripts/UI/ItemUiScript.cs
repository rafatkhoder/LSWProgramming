using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class ItemUiScript : MonoBehaviour
{
    public int id;
    public Image bordar;
    public Image itemImg;
    public TMP_Text itemCount;
    public int price;
    public int count;
    private string name;

    private bool isSelect = false;
    public bool _isSelect { get {return isSelect; } set {  isSelect = value; } }

    public delegate void ItemInteractEvent();
    public event ItemInteractEvent onItemClicked ;

    internal void SetCellData(Sprite itemImgData , int id ,string name ,int count , int price)
    {
        itemImg.sprite = itemImgData;
        this.name = name;
        this.id = id;
        this.price = price;
        this.count = count;
        itemCount.text = count > 0 ? this.count.ToString() : "";

       
    }
    public void DestroyMe()
    {
        this.gameObject.SetActive(false);
        Destroy(this.gameObject, 1f);
    }

    public void SelectItem()
    {
        bordar.enabled = true;
        
    }
    //public void DeSelectItem()
    //{
    //    bordar.enabled = false;
    //}

  

    public void OnPointerClick(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = (PointerEventData)baseEventData;
        if (pointerEventData.button == PointerEventData.InputButton.Left)
            onItemClicked?.Invoke();
    }


    public void delegateData()
    {
        onItemClicked += HandleItemSelection;


    }
    private void HandleItemSelection()
    {
        ChangeButtonState();
        MainCanvasUIScript.Instance.inventoryUiPanelScript.DeSelectItem();
        MainCanvasUIScript.Instance.inventoryUiPanelScript._selectItem = this;

        SelectItem();
        MainCanvasUIScript.Instance.inventoryUiPanelScript.descriptionItemUIScript.cellData(this.itemImg.sprite, this.name, this.price);
    }


    public void ChangeButtonState()
    {
        string bottunState = ScriptbleObjectData.Instance.selectData.storeItems[this.id].IsState();
        MainCanvasUIScript.Instance.inventoryUiPanelScript.descriptionItemUIScript.buttonItemUIScript.ShowButton(bottunState);
    }

    public void RemoveItem()
    {
        MainCanvasUIScript.Instance.inventoryUiPanelScript.DestroyListItems();
        //MainCanvasUIScript.Instance.inventoryUiPanelScript.InitlizeInventoryItem();
        gameObject.SetActive(false);
        gameObject.transform.SetParent(null);
    }
}

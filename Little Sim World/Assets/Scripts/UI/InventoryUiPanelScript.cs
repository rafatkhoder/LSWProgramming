using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class InventoryUiPanelScript : MonoBehaviour
{
    [SerializeField]
    private ItemUiScript itemUiScript;
    public List<ItemUiScript> listIUiItem = new List<ItemUiScript>();

    [SerializeField]
    private RectTransform inventoryTrsansform;
    [SerializeField]
    public DescriptionItemUIScript descriptionItemUIScript;
    [SerializeField]
    private Button closeBtn;

    private ItemUiScript selectItem;
    public ItemUiScript _selectItem {  get { return selectItem; } set {selectItem = value; } }
    
    private ItemUiScript previousSelectItem;
    public ItemUiScript _previousSelectItem {  get { return selectItem; } set {selectItem = value; } }
    

    
    
    public void ActivateCloseBtn()
    {
        closeBtn.onClick.AddListener(HideMenu);
        
    }
    void HideMenu( )
    {
        MainCanvasUIScript.Instance.Hide(this.gameObject);
    }
   

  
    public void InitlizeInventoryItem()
    {
        listIUiItem.Clear();

        for (int i = 0; i < ScriptbleObjectData.Instance.selectData.storeItems.Count; i++)
        {
            ItemUiScript item = Instantiate(itemUiScript, Vector3.zero, Quaternion.identity);
            item.transform.SetParent(inventoryTrsansform);
            item.name = ScriptbleObjectData.Instance.selectData.storeItems[i].storeItemsName;

            item.SetCellData(
                ScriptbleObjectData.Instance.selectData.storeItems[i].storeItemsImg, i,
                ScriptbleObjectData.Instance.selectData.storeItems[i].storeItemsName,
                ScriptbleObjectData.Instance.selectData.storeItems[i].storeItemsCount,
                ScriptbleObjectData.Instance.selectData.storeItems[i].itemPrice
            );

            item.delegateData();
            listIUiItem.Add(item);
        }
    }





    public ItemUiScript DeSelectItem()
    {
        foreach (var item in listIUiItem)
        {
          
            item.bordar.enabled = false ;
      
        }
        return previousSelectItem;
    }

    public void DestroyListItems()
    {
        if (listIUiItem != null)
        {
            foreach (var item in listIUiItem)
            {
                item.DestroyMe();
            }
            listIUiItem.Clear();
        }
    }

}

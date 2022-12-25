using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName = "StoreData", menuName = "storeData")]
public class PlayerStoreData : ScriptableObject
{
    public List<StoreItem> storeItems = new List<StoreItem>();

    public void AddNewITem(Sprite storeItemsImg, string storeItemsName, int storeItemsCount, int itemPrice)
    {
        // Check if the new item already exists in the list
        bool itemExists = storeItems.Any(item => item.storeItemsName == storeItemsName && item.itemPrice == itemPrice);

        if (!itemExists)
        {
            // If the item does not exist, add it to the list
            StoreItem newITem = new StoreItem();
            newITem.storeItemsImg = storeItemsImg;
            newITem.storeItemsName = storeItemsName;
            newITem.storeItemsCount = storeItemsCount;
            newITem.itemPrice = itemPrice;
            storeItems.Add(newITem);
        }
        else
        {
            // If the item already exists, update the count
            StoreItem existingItem = storeItems.First(item => item.storeItemsName == storeItemsName && item.itemPrice == itemPrice);
            existingItem.storeItemsCount += storeItemsCount;
        }
    }


}
[System.Serializable]
public class StoreItem
{
    public Sprite storeItemsImg  ;
    public string storeItemsName  ;
    public int storeItemsCount ;
    public int itemPrice = 0 ;
    public enum ItemState
    {
        buy,sell,equip
    }
    public ItemState itemState;

    public string IsState()
    {
        // Check if the current store is the shop
        if (ScriptbleObjectData.Instance.store == ScriptbleObjectData.Store.Shop)
        {
            itemState = ItemState.sell;
           
        }
        else
        {
            // Set the item state based on the current store
            itemState = ScriptbleObjectData.Instance.store == ScriptbleObjectData.Store.PersonalItems ?
                ItemState.equip : ItemState.buy;
        }
        return itemState.ToString();
    }


}

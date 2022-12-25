using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScriptbleObjectData : MonoBehaviour
{
    public static ScriptbleObjectData Instance;

    public PlayerStoreData playerClothsStoreData;
    public PlayerStoreData StoreData;
    public PlayerStoreData VegetableStoreData;
    public PlayerStoreData personalItemsData;

    public PlayerStoreData selectData;
    public Sprite defaultSpriteDescrition;
    public enum Store
    {
        Shop, VegetableStore, House ,PersonalItems
    }
    public Store store;
    private void Awake()
    {
        Instance = this;
        personalItemsData.storeItems.Clear();
    }
    public void RestSelectData()
    {
        if(selectData.storeItems != null) selectData.storeItems.Clear();
#if UNITY_EDITOR
        EditorUtility.SetDirty(selectData);
#endif
        MainCanvasUIScript.Instance.inventoryUiPanelScript.DestroyListItems();
    }


    // Change the store to see the interface that appears to the user in ui panel
    public void ChangeStore(Store store)
    {
        switch (store)
        {

            case Store.House:
                this.store = Store.House;
                selectData.storeItems.AddRange(playerClothsStoreData.storeItems);
                break;
            case Store.Shop:
                this.store = Store.Shop;
         
                selectData.storeItems.AddRange(personalItemsData.storeItems);
                foreach (var item in selectData.storeItems)
                {
                    item.itemState = StoreItem.ItemState.sell;
                }
                break;
            case Store.VegetableStore:
                this.store = Store.VegetableStore;
                
                selectData.storeItems.AddRange(VegetableStoreData.storeItems);
                
                break;
            default:
                this.store = Store.PersonalItems;
                selectData.storeItems.AddRange(personalItemsData.storeItems);
                break;
        }
    }

    public void ChngeStoreData(RaycastHit2D hit)
    {
        Store store =(Store)Enum.Parse(typeof(Store), hit.collider.gameObject.tag);
        ChangeStore(store);
        // Invoke the OnInteract event
        PlayerInteraction.OnInteractEventActviate();
    }

    public void ChangerStoreToPlayerData()
    {
            ChangeStore(Store.PersonalItems);
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ButtonItemUIScript : MonoBehaviour
{
    [SerializeField] private Button buy, sell, equip, unequip;



    private void OnEnable()
    {
        buy.gameObject.SetActive(false);
        sell.gameObject.SetActive(false);
        equip.gameObject.SetActive(false);
        unequip.gameObject.SetActive(false);
    }


    public void ShowButton(string stateButton)
    {
        buy.gameObject.SetActive(stateButton == StoreItem.ItemState.buy.ToString());
        sell.gameObject.SetActive(stateButton == StoreItem.ItemState.sell.ToString());
        ButtonState(stateButton);
    }

    private void ButtonState(string stateButton)
    {
        if (stateButton == StoreItem.ItemState.equip.ToString() &&
            ScriptbleObjectData.Instance.store == ScriptbleObjectData.Store.PersonalItems)
        {
            if (Player.Instance.playerEquipment._playerItems != null && MainCanvasUIScript.Instance.inventoryUiPanelScript._selectItem != null)
            {
                bool isEquipped = Player.Instance.playerEquipment._playerItems.Count > 0
                      && Player.Instance.playerEquipment._playerItems[0].gameObject.activeInHierarchy
                      && MainCanvasUIScript.Instance.inventoryUiPanelScript._selectItem.name ==
                         Player.Instance.playerEquipment._playerItems[0].name;

                equip.gameObject.SetActive(!isEquipped);
                unequip.gameObject.SetActive(isEquipped);
            }
        }
    }


    public void BuyItem()
    {
        ItemUiScript item = MainCanvasUIScript.Instance.inventoryUiPanelScript._selectItem;

        // Check if the player has enough coins to buy the item
        if (LevelManger.Instance.coinCount >= item.price)
        {
            // Deduct the price of the item from the player's coin balance
            LevelManger.Instance.coinCount -= item.price;

            // Add the item to the player's inventory
            ScriptbleObjectData.Instance.personalItemsData.AddNewITem(item.itemImg.sprite, item.name, 1, item.price);

            // Update the UI
            MainCanvasUIScript.Instance.coinUIScript.UpdateUiCoins(-item.price);
        }
        else
        {
            // Display a message indicating that the player doesn't have enough coins to buy the item
            Debug.Log("Not enough coins to buy this item.");
        }
    }

    public void SellItem()
    {
        ItemUiScript item = MainCanvasUIScript.Instance.inventoryUiPanelScript._selectItem;

        if (item != null)
        {
            // Add the sale price of the item to the player's coin balance
            LevelManger.Instance.coinCount += item.price;
            // Remove the item from the list
            RemoveItem(item);
            // Update the UI
            MainCanvasUIScript.Instance.inventoryUiPanelScript.InitlizeInventoryItem();
            MainCanvasUIScript.Instance.coinUIScript.UpdateUiCoins(item.price);
            // rest description Values
            MainCanvasUIScript.Instance.inventoryUiPanelScript.descriptionItemUIScript.RestDescription();
        }
        else
        {
            // Display a message indicating that the selected item was not found in the list
            Debug.Log("Selected item not found in list.");
        }
    }

    void RemoveItem(ItemUiScript item)
    {
    
        ScriptbleObjectData.Instance.personalItemsData.storeItems.RemoveAt(item.id);
        ScriptbleObjectData.Instance.selectData.storeItems.RemoveAt(item.id);
        MainCanvasUIScript.Instance.inventoryUiPanelScript.listIUiItem[item.id].RemoveItem();
        Player.Instance.playerEquipment.RemoveSelectedItem(item.name, item.price);
    }

    public void EquipItemBtn()
    {
        ItemUiScript item = MainCanvasUIScript.Instance.inventoryUiPanelScript._selectItem;

        if (item.name == GameStrings.RedHero || item.name == GameStrings.PinkHero || item.name == GameStrings.BlueHero)
        {
            Player.Instance.PlayerCloothes.ChangeClothes(item.name);
        }

        Player.Instance.playerEquipment.ActivateItemObject(item.name, item.price);
        ButtonState(StoreItem.ItemState.equip.ToString());
    }



    public void UnequipItem()
    {
        ItemUiScript item = MainCanvasUIScript.Instance.inventoryUiPanelScript._selectItem;

        if (item != null)
        {
            // Deactivate the equipped item
            Player.Instance.playerEquipment.DeactivateAllItems();
        }
        else
        {
            // Display a message indicating that the selected item was not found in the list
            Debug.Log("Selected item not found in list.");
        }
        ButtonState(StoreItem.ItemState.equip.ToString());
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PayerEquipmentT : MonoBehaviour
{
    public List<ItemCommpontManger> playerItems = new List<ItemCommpontManger>();
    public List<ItemCommpontManger> _playerItems { get { return playerItems; } set { playerItems = value; } }

    public void ActivateItemObject(string storeItemsName, int itemPrice)
    {
        // Check if the new item already exists in the list
        bool itemExists = playerItems.Any(item => item.name == storeItemsName && item.price == itemPrice);

        if (itemExists)
        {
            // Disable all objects in the list
            foreach (ItemCommpontManger item in playerItems)
            {
                item.gameObject.SetActive(false);
            }

            // Enable the selected object
            ItemCommpontManger selectedItem = playerItems.First(item => item.name == storeItemsName && item.price == itemPrice);
            selectedItem.gameObject.SetActive(true);
            selectedItem._equiptObject = true;
        }
    }

    public void RemoveSelectedItem(string storeItemsName, int itemPrice)
    {
        // Check if the item exists in the list
        bool itemExists = playerItems.Any(item => item.name == storeItemsName && item.price == itemPrice);

        if (itemExists)
        {
            // Find the selected item in the list
            ItemCommpontManger selectedItem = playerItems.First(item => item.name == storeItemsName && item.price == itemPrice);

            // Remove the selected item from the list
            playerItems.Remove(selectedItem);
            // Remove the selected item from hierarchy
            Destroy(selectedItem.gameObject);
        }
    }

    public void DeactivateAllItems()
    {
        // Deactivate all objects in the list
        foreach (ItemCommpontManger item in playerItems)
        {
            item.gameObject.SetActive(false);
        }
    }
}

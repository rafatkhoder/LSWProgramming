using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvasUIScript : MonoBehaviour
{
    public static MainCanvasUIScript Instance;
    public InventoryUiPanelScript inventoryUiPanelScript;
    public CoinUIScript coinUIScript;
    



    private void Awake()
    {
        Instance = this;
           
    }


    private void Start()
    {
        // Subscribe to the OnInteract event
        PlayerInteraction.OnInteract += InteractWithStore;
        inventoryUiPanelScript.ActivateCloseBtn();
        inventoryUiPanelScript.descriptionItemUIScript.RestDescription();
        ScriptbleObjectData.Instance.RestSelectData();

    }

    public bool PanelIsActive()
    {
        return inventoryUiPanelScript.isActiveAndEnabled;
    }
    public void InteractWithStore()
    {
        // Display the store interface
        Show(inventoryUiPanelScript.gameObject);
        inventoryUiPanelScript.InitlizeInventoryItem();

    }

    private void Update()
    {
        if (InputManger.Instance.InvetoryInput())
        {
            if (PanelIsActive())
            {
                Hide(inventoryUiPanelScript.gameObject);
            //    ScriptbleObjectData.Instance.RestSelectData();
            }
            else
            {
                Show(inventoryUiPanelScript.gameObject);
                ScriptbleObjectData.Instance.ChangerStoreToPlayerData();
                InteractWithStore();
            }
        }
    }

     public void Show(GameObject item) { item.SetActive(true); }
     public void Hide(GameObject item) 
     {
        
        item.SetActive(false);
        inventoryUiPanelScript.descriptionItemUIScript.RestDescription();
        ScriptbleObjectData.Instance.RestSelectData();

    }
}

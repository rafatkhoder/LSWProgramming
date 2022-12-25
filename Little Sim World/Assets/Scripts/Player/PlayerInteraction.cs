using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 1.5f; // the distance at which the player
    private bool isInteractable; // is the store currently interactable by the player

    
    public delegate void InteractEvent();
    public static event InteractEvent OnInteract,OnPick,OnDrop;

    private GameObject hitObject;


    void Update()
    {
        HitChest();
        HitStores();
    }
    public static void OnInteractEventActviate()
    {
        OnInteract?.Invoke();
    }

    void HitStores()
    {
        if (IsHitStore() && !MainCanvasUIScript.Instance.PanelIsActive())
        {
            // Raycast from the player's position in the direction they are facing
            RaycastHit2D hit = RaycastUtility.CastRayFromMouse();

            if (hit.collider != null)
            {
                // If the raycast hits the store game object
                if (hit.collider.gameObject.tag == GameStrings.StoreObject)
                {
                    ScriptbleObjectData.Instance.ChngeStoreData(hit);

                }
                else if (hit.collider.gameObject.tag == GameStrings.VegetableStore)
                {
                    ScriptbleObjectData.Instance.ChngeStoreData(hit);
                }
                else if (hit.collider.gameObject.tag == GameStrings.House)
                {
                    ScriptbleObjectData.Instance.ChngeStoreData(hit);
                }

            }

        }
    }

   

    bool IsHitStore()
    {
        return isInteractable && InputManger.Instance.mouseButton && hitObject != null ;
    }

    void HitChest()
    {
        if (InputManger.Instance.mouseButton)
        {
            RaycastHit2D hit = RaycastUtility.CastRayFromMouse();
            if (hit.collider != null)
            {
                float currentDis = Vector2.Distance(hit.collider.gameObject.transform.position, this.gameObject.transform.position);
                if (currentDis > interactionDistance)
                {
                    return;
                }

                ContainerItem containerItem = null;
                ItemCommpontManger itemCommpontManger = null;
                BagCoins bagCoins = null;
                string hitName = hit.collider.gameObject.tag;
                bool checkAxe =false;

                if(hitName == GameStrings.Chest ||
                    hitName == GameStrings.Tree)
                {
                    containerItem = hit.collider.gameObject.GetComponent<ContainerItem>();
                }
               
                else if (hitName == GameStrings.BagCoin)
                {
                    bagCoins = hit.collider.gameObject.GetComponent<BagCoins>();
                }
                else if (hitName == GameStrings.Axe ||
                         hitName == GameStrings.Wood)
                {
                    itemCommpontManger = hit.collider.gameObject.GetComponent<ItemCommpontManger>();
                }
                else { return; }


                if (containerItem != null)
                {
                    if (hitName == GameStrings.Tree && Player.Instance.playerEquipment._playerItems.Count > 0)
                    {
                        checkAxe = Player.Instance.playerEquipment._playerItems[0]._equiptObject;
                        containerItem.HitTargetEqiupItem(checkAxe);
                    }
                    else { containerItem.HitTarget(); }
                }
                else if (bagCoins != null)
                {
                    ScriptbleObjectData.Instance.personalItemsData.AddNewITem(bagCoins.sprit, bagCoins.name, bagCoins.count, bagCoins.price);
                    Destroy(hit.collider.gameObject);
                }
                else if (itemCommpontManger != null)
                {
                    ScriptbleObjectData.Instance.personalItemsData.AddNewITem(itemCommpontManger.sprit, itemCommpontManger.name, itemCommpontManger.count, itemCommpontManger.price);
                    AddObjectTolayer(hit);
                }
            }
        }
    }

    private void AddObjectTolayer(RaycastHit2D hit)
    {
        if (hit.collider.tag == GameStrings.Axe)
        {
            Collider2D objectHit = hit.collider;
            objectHit.enabled = false;
            Player.Instance.playerEquipment._playerItems.Add(objectHit.gameObject.GetComponent<ItemCommpontManger>());
            objectHit.transform.SetParent(Player.Instance.playerEquipment.transform);
            objectHit.transform.localPosition = new Vector3(0, 0, 0);
            objectHit.gameObject.SetActive(false);
        }
        else
        {
            Destroy(hit.collider.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        string[] storeTags = { GameStrings.StoreObject, GameStrings.VegetableStore, GameStrings.House };
        foreach (string tag in storeTags)
        {
            IsTargetOnTrigger(collision, tag);
        }
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        string[] storeTags = { GameStrings.StoreObject, GameStrings.VegetableStore, GameStrings.House };
        foreach (string tag in storeTags)
        {
            IsTargetOutTrigger(collision, tag);
        }
    }




    void IsTargetOnTrigger(Collider2D collision, string targetTag)
    {
        if (collision.gameObject.tag == targetTag)
        {
            isInteractable = true;
            hitObject = collision.gameObject;
        }
    }
    void IsTargetOutTrigger(Collider2D collision, string targetTag)
    {
        if (collision.gameObject.tag == targetTag)
        {
            isInteractable = false;
            hitObject = null;
        }
    }
}

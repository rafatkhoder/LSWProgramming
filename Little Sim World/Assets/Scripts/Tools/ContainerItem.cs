using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerItem : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> items = new List<GameObject>();
    public List<GameObject> _items
    {
        get { return items; }
        set { items = value; }
    }
    [SerializeField]
    private float destroyTime = 0.2f;
    private int dropCount;
    private float randonNum;

    

    public virtual void Start()
    {
        dropCount = items.Count;
    }


    public void HitTarget()
    {
        DropItem();
    }
    public void HitTargetEqiupItem(bool PlayerHasRequiredItem)
    {
        if (PlayerHasRequiredItem)
        {
            DropItem();

        }
    }
    void DropItem()
    {
        foreach (GameObject item in items)
        {
            randonNum = Random.Range(.2f, 3f);
            // calculating where items will drop
            Vector3 position = transform.position;
            position.x -= randonNum;
            position.y -= randonNum;

            GameObject newObject = Instantiate(item);
            newObject.transform.position = position;
        }

        Destroy(gameObject, destroyTime);
    }
}

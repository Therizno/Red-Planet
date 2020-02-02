using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private GameManager gm;

    private List<GameObject> inventoryItems;

    //Awake is called before the first frame update
    void Awake()
    {
        inventoryItems = new List<GameObject>();
    }

    // Start is called after awake (use for getting other objects)
    void Start()
    {
        gm = GameManager.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Item Pickup") != 0)
        {
            GameObject g = gm.getPlayerPickupItem();

            if (g != null)
            {
                addToInventory(g);
            }
        }
    }


    public void addToInventory(GameObject item)
    {
        inventoryItems.Add(item);
        item.GetComponent<ItemBehavior>().toggleCarrying();

        //pull item with player
        item.transform.parent = transform;

        toggleItemEnabled(item);

    }

    private void toggleItemEnabled(GameObject g)
    {
        BoxCollider2D coll = g.GetComponent<BoxCollider2D>();
        Rigidbody2D rgbd = g.GetComponent<Rigidbody2D>();
        SpriteRenderer sprt = g.GetComponent<SpriteRenderer>();

        if (coll != null)
        {
            coll.enabled = !coll.enabled;
        }
        if (rgbd != null)
        {
            rgbd.isKinematic = !rgbd.isKinematic;
        }
        if (sprt != null)
        {
            sprt.enabled = !sprt.enabled; 
        }
    }
}

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

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] string inventoryHUDObjectName;


    private TMP_Text inventory;

    private PlayerBehavior playerBehavior;

    //Awake is called before the first frame update
    void Awake()
    {

    }

    // Start is called before the first frame update (use for getting other objects)
    void Start()
    {
        playerBehavior = player.GetComponent<PlayerBehavior>();

        //get HUD objects 
        foreach (Transform child in transform)
        {
            if (child.gameObject.name == inventoryHUDObjectName)
            {
                inventory = child.gameObject.GetComponent<TMP_Text>();
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        string invntString = getInventoryList();
        inventory.text = "Inventory: " + (invntString != ""? invntString : "empty");
    }


    private string getInventoryList()
    {
        List<ItemType> items = playerBehavior.getInventory();
        
        items.Sort();

        ItemType lastItem = ItemType.NullType;
        string s = ""; 
        int itemCount = 1;

        foreach (ItemType itm in items)
        {
            if (itm == lastItem)
            {
                itemCount++;
            }
            else if (lastItem != ItemType.NullType)
            {
                s += lastItem; 
                s += ": " + itemCount + ", "; 
                itemCount = 1;
            }
            
            lastItem = itm;
        }

        if (lastItem != ItemType.NullType)
        {
            s += lastItem;
            s += ": " + itemCount;
        }

        return s;
    }
}

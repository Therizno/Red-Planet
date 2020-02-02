using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] string inventoryHUDObjectName;


    private TextMesh inventory;

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
                inventory = child.gameObject.GetComponent<TextMesh>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
            else
            {
                s += itm;
                s += ": " + itemCount + " "; 
                itemCount = 1;
            }

            lastItem = itm;
        }

        return s;
    }
}

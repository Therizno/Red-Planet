using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float itemPickupDistance;

    [SerializeField] private GameObject player;


    private List<GameObject> items;

    private PlayerMovement playerMovement;
    private PlayerBehavior playerBehavior;


    //singleton methods
    private static GameManager g;

    private GameManager()
    {

    }

    public static GameManager getInstance()
    {
        return g;
    }

    private void Awake()
    {
        if (g == null)
        {
            g = this;
        }

        items = new List<GameObject>();
    }
    //end singleton methods


    // Start is called before the first frame update (use for getting other objects)
    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        playerBehavior = player.GetComponent<PlayerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    //call every time an item is spawned
    public void addNewItem(GameObject g)
    {
        items.Add(g);
    }

    public bool takeItemFromPlayer(ItemType itm)
    {
        return playerBehavior.destroyInventoryItemByEnum(itm);
    }



    //getters and setters


    //returns an arbirary nearby iten that the player can pick up
    public GameObject getPlayerPickupItem()
    {

        foreach (GameObject itm in items)
        {
            if (itm.GetComponent<ItemBehavior>().playerCanPickup())
            {
                return itm;
            }
        }

        return null;
    }

    public float getDistanceFromPlayer(GameObject g)
    {
        float relX = player.transform.position.x - g.transform.position.x;
        float relY = player.transform.position.y - g.transform.position.y;

        return Mathf.Sqrt((relX * relX) + (relY * relY));
    }

    public bool isPlayerJumping()
    {
        return playerMovement.isJumping();
    }

    public float getPlayerSpeed()
    {
        return playerMovement.getMoveSpeed();
    }

    public float getPlayerJumpSpeed()
    {
        return playerMovement.getJumpSpeed();
    }

    public float getPlayerX()
    {
        return player.transform.position.x;
    }
    public float getPlayerY()
    {
        return player.transform.position.y;
    }
    public float getPlayerZ()
    {
        return player.transform.position.z;
    }

    public float getItemPickupDistance()
    {
        return itemPickupDistance;
    }
}

public enum ItemType
{
    Bucket, Junk, Fuel, Thruster, Wrench, RoverSensor 
}

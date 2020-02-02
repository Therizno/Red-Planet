using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    private GameManager gm;

    private bool isPlayerCarrying;
    private bool isPlayerNearby;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.getInstance();

        gm.addNewItem(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool playerCanPickup()
    {
        isPlayerNearby = gm.getDistanceFromPlayer(gameObject) < gm.getItemPickupDistance();

        return !isPlayerCarrying && isPlayerNearby;
    }

    public void toggleCarrying()
    {
        isPlayerCarrying = !isPlayerCarrying;
    }
}

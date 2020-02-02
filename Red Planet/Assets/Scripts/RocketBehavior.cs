using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehavior : MonoBehaviour
{
    private GameManager gm;

    [SerializeField] private float rocketItemPickupDistance;


    [SerializeField] private ItemType itemReq1;
    [SerializeField] private int itemReqNum1;

    [SerializeField] private ItemType itemReq2;
    [SerializeField] private int itemReqNum2;

    [SerializeField] private ItemType itemReq3;
    [SerializeField] private int itemReqNum3;

    [SerializeField] private ItemType itemReq4;
    [SerializeField] private int itemReqNum4;



    private Dictionary<ItemType, int> repairPieces;

    // Awake is called before the first frame update
    void Awake()
    {
        repairPieces = new Dictionary<ItemType, int>();

        repairPieces.Add(itemReq1, itemReqNum1);
        repairPieces.Add(itemReq2, itemReqNum2);
        repairPieces.Add(itemReq3, itemReqNum3);
        repairPieces.Add(itemReq4, itemReqNum4);
    }

    // Start is called before the first frame update (use for getting other objects)
    void Start()
    {
        gm = GameManager.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
        takePlayerItems(); 
    }


    private void takePlayerItems()
    {
        ItemType itemTypeRemoved = ItemType.NullType;

        if (gm.getDistanceFromPlayer(gameObject) < gm.getItemPickupDistance())
        {
            foreach (KeyValuePair<ItemType, int> pair in repairPieces)
            {
                if (pair.Value > 0)
                {
                    if (gm.takeItemFromPlayer(pair.Key))
                    {
                        itemTypeRemoved = pair.Key;
                        break;
                    }
                }
            }
        }

        if (itemTypeRemoved != ItemType.NullType)
        {
            repairPieces[itemTypeRemoved]--; 
        }
        
    }
}

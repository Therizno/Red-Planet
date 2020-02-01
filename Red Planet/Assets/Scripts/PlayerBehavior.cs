using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    List<GameObject> inventoryItems;


    void Awake()
    {
        inventoryItems = new List<GameObject>();
    }

    // Start is called after awake (use for getting other objects)
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToInventory(GameObject item)
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private PlayerMovement playerMovement;


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
    }
    //end singleton methods


    // Start is called before the first frame update (use for getting other objects)
    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool isPlayerJumping()
    {
        return playerMovement.isJumping();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get raw input 
        float horzInput = Input.GetAxis("Horizontal"); 

        //calculate move direction
        Vector2 movement = new Vector2(horzInput + transform.position.x, transform.position.y);

        //actually move the player
        transform.position = Vector2.MoveTowards(transform.position, movement, speed);
    }
}

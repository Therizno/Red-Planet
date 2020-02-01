using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float jumpLength;
    [SerializeField] private float jumpCooldown;

    private bool jumping;
    private float timeInAir;
    private float timeSinceLand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // FixedUpdate is called once per fixed length of time 
    void FixedUpdate()
    {
        //get raw input 
        float horzInput = Input.GetAxis("Horizontal");
        float vertInput = Mathf.Max(Input.GetAxis("Vertical"), Input.GetAxis("Jump"));

        //calculate move direction
        Vector2 movement = new Vector2(horzInput + transform.position.x, jumpModifier(vertInput) + transform.position.y);

        //actually move the player
        transform.position = Vector2.MoveTowards(transform.position, movement, speed);

    }


    private float jumpModifier(float vertInput)
    {
        float yMove = 0;

        if (jumping)
        {
            timeSinceLand = 0;

            //apply jump energy
            yMove = jumpSpeed;

            //check if still jumping
            jumping = timeInAir < jumpLength;

            //increment
            timeInAir += Time.deltaTime;
        }
        else
        {
            timeInAir = 0;

            //check if jumping
            jumping = vertInput > 0 && timeSinceLand > jumpCooldown;

            //increment
            timeSinceLand += Time.deltaTime;
        }

        return yMove;
    }
}

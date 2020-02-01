using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{ 
    private GameManager gm;


    [SerializeField] private float runAnimMultiplier;
    [SerializeField] private float jumpAnimMultiplier;
    [SerializeField] private float idleAnimSpeed;


    private Animator anim;


    // Start is called before the first frame update (use for getting other objects)
    void Start()
    {
        gm = GameManager.getInstance();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("jumping", gm.isPlayerJumping());
        anim.SetFloat("speed", gm.getPlayerSpeed() * runAnimMultiplier);
        anim.SetBool("isMoving", gm.getPlayerSpeed() > 0);
        anim.SetFloat("jumpSpeed", gm.getPlayerJumpSpeed() * jumpAnimMultiplier);
        anim.SetFloat("idleSpeed", idleAnimSpeed);
    }
}

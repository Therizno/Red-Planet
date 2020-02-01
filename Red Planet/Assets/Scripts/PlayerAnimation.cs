using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{ 
    private GameManager gm;


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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb_pl;
    Vector2 moveInput_pl;
    SpriteRenderer sprite_pl;
    public float moveSpeed_pl;
    //Animator animator_pl;
    private void Awake()
    {
        rb_pl = GetComponent<Rigidbody2D>();
        sprite_pl = GetComponent<SpriteRenderer>();
        //animator_pl = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb_pl.velocity = moveInput_pl * moveSpeed_pl;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        #region ÒÆ¶¯
        moveInput_pl.x = Input.GetAxisRaw("Horizontal");
        moveInput_pl.y = Input.GetAxisRaw("Vertical");

        moveInput_pl=moveInput_pl.normalized;
        #endregion

        /*if(moveInput_pl==Vector2.zero)
        {
            animator_pl.SetBool("isWalking", false);
        }
        else
        {
            animator_pl.SetBool("iswalking", true);
            if(moveInput_pl.x>0)
            {
                sprite_pl.flipX = false;
            }
            else if(moveInput_pl.x<0)
            {
                sprite_pl.flipX=true;
            }
        }*/

    }
}

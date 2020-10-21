﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    [SerializeField] private float JumpVelocity = 5f;
    private float jumpTimeCounter;
    public float jumpTime;
    [SerializeField] private bool isJumping = false;
    private bool fallSpeedTrig = false;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    private double start_X_position = 0;
    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        start_X_position = this.gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        fixPosition();
        
    }

    void fixPosition(){
        if(this.gameObject.transform.position.x < start_X_position){
            transform.Translate(Vector3.right * Time.deltaTime * 3);
        }
    }

    private bool touchCheck(Vector2 direction, float distance) {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, direction, distance, platformsLayerMask);
        return raycastHit2d.collider != null;
    }

    private void Jump(){
        //rigidbody2d.velocity = Vector2.up * JumpVelocity;
        if(Input.GetButtonDown("Jump") && touchCheck(Vector2.down, 0.1f)){
            isJumping=true;
            rigidbody2d.velocity = Vector2.up * JumpVelocity;
            jumpTimeCounter=jumpTime;
        }

      //Variable Jump Height
        if(Input.GetButton("Jump") && isJumping==true){
            if(jumpTimeCounter>0){
                rigidbody2d.velocity = Vector2.up * JumpVelocity;
                jumpTimeCounter -=Time.deltaTime;
                fallSpeedTrig = true;
            }
        }

        if(touchCheck(Vector2.up,0.2f) && isJumping == true){//Is Head hitted?
            rigidbody2d.velocity= new Vector2(0,0);
            fallSpeedTrig=false;
            isJumping = false;
            Debug.Log("Head Hit");
        }else 
        if(Input.GetButtonUp("Jump")){//Is Jump button reelased?
            if(fallSpeedTrig==true && isJumping == true){
                if(rigidbody2d.velocity.y>4){
                    rigidbody2d.velocity= new Vector2(0,4);
                }
                
            }
            fallSpeedTrig=false;
            isJumping = false;
        }
        
    }
}

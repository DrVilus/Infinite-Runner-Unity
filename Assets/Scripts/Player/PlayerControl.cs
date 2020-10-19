using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    [SerializeField] private float JumpVelocity = 5f;
    private float jumpTimeCounter;
    public float jumpTime;
    [SerializeField] private bool isJumping;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        
    }

    private bool IsGrounded() {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 0.1f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }

    private void Jump(){
        //rigidbody2d.velocity = Vector2.up * JumpVelocity;
        if(Input.GetButtonDown("Jump") && IsGrounded()){
            isJumping=true;
            rigidbody2d.velocity = Vector2.up * JumpVelocity;
            jumpTimeCounter=jumpTime;
        }


      //Variable Jump Height
        if(Input.GetButton("Jump") && isJumping==true){
            if(jumpTimeCounter>0){
                rigidbody2d.velocity = Vector2.up * JumpVelocity;
                jumpTimeCounter -=Time.deltaTime;
            } else {
                isJumping = false;
            }
        }
      
        if(Input.GetButtonUp("Jump")){
            isJumping = false;
        }
        
    }
}

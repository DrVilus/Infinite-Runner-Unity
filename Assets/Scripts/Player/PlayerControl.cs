using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private Animator playerAnimation;

    private Coroutine kickflag;
    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        start_X_position = this.gameObject.transform.position.x;
        playerAnimation = this.transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        fixPosition();
        if(isJumping==true){
            playerAnimation.SetBool("isJumping",true);
        }else{
            playerAnimation.SetBool("isJumping",false);
        }

        if (rigidbody2d.velocity.y < -0.1 || rigidbody2d.velocity.y > 0.1)
        {
            playerAnimation.SetBool("inAir",true);
        }

        if(touchCheck(Vector2.down, 0.1f)){
            playerAnimation.SetBool("inAir",false);
        }
             if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale != 0)
            {
                Time.timeScale = 0;
                
            }else if(Time.timeScale ==0){
                Time.timeScale = 1;
            }

        }
        if(Input.GetKeyDown("p")){
            SceneManager.LoadScene(0);
        }
        if(GlobalSettings.kickready==true){
            if(Input.GetMouseButton(0)){
                playerAnimation.SetBool("isSliding",true);
                playerAnimation.SetBool("Stand",false);
                GlobalSettings.kicked=true;
                kickflag = StartCoroutine(Slidekick()); 
            }
        }
    }
    private IEnumerator Slidekick(){
        yield return new WaitForSeconds(0.5f);
        playerAnimation.SetBool("isSliding",false);
                playerAnimation.SetBool("Stand",true);
                GlobalSettings.kicked=false;
                GlobalSettings.kickready=false;
    }
    void FixedUpdate()
    {
        
    }

    void fixPosition(){
        if(this.gameObject.transform.position.x < start_X_position){
            transform.Translate(Vector3.right * Time.deltaTime * 5);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAnimationStateController : MonoBehaviour
{
    Animator animator;
    float blendZ = 0.0f;
    float blendX = 0.0f;
    public float acceleration = 2.0f;
    public float deceleration =2.0f;
    public float maximumWalkVelocity = 0.5f;
    public float maximumRunVelocity = 2.0f;
    public float crippleCount = 0.0f;
    // Start is called before the first frame update
    public bool obstacleHit;
    public bool whileHit;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("obstacleHit",false);
        obstacleHit = animator.GetBool("obstacleHit");
        

    }
    
    // Update is called once per frame
    void Update()
    {
        bool forwardPress = Input.GetKey("w");
        bool leftPress = Input.GetKey("a");
        bool rightPress = Input.GetKey("d");
        bool slidePress = Input.GetKey("s");
        bool isSlide = animator.GetBool("isSlide");
        bool jumpPress = Input.GetKey("space");
        bool isJump = animator.GetBool("isJump");
        bool runPress = Input.GetKey("left shift");
        bool hit = Input.GetKey("k");
        float turning = Input.acceleration.x;
        float jumpOrSlide = Input.acceleration.y;

        if(hit){
            obstacleHit = true;
            crippleCount = 0.0f;
        }
        if(obstacleHit){
            crippleCount ++;
            if(crippleCount < 300.0f){
                obstacleHit = false;
            }
        }

        

        float currentMaxVelocity = runPress ? maximumRunVelocity : maximumWalkVelocity;
        // start walking to running

        if(!obstacleHit){
            if(blendZ < maximumRunVelocity ){
                blendZ += Time.deltaTime * acceleration;
            }
            // turn left
            if((leftPress||turning < -0.3f) && (blendX > -2) ){
                blendX -= Time.deltaTime * acceleration;
            }
            // turn right
            if((rightPress||turning > 0.3f) && (blendX < 2) ){
                blendX += Time.deltaTime * acceleration;
            }
            //Deceleration left/right
            if((!leftPress||(turning>-0.3f&&turning<0.0f)) && (blendX < 0.0f)){
                blendX += Time.deltaTime * deceleration;
            }
            if((!rightPress||(turning<0.3f&&turning>0.0f)) && (blendX > 0.0f)){
                blendX -= Time.deltaTime * deceleration;
            }

            // Set velocity on the x axis to zero
            if((!leftPress||(turning>-0.3&&turning<0.0)) && (!rightPress||(turning<0.3&&turning>0.0)) && blendX != 0.0f && (blendX > -0.05f && blendX < 0.05f)){
                blendX = 0.0f;
            }
        }
        // Slow down if obstacle hit
        if(obstacleHit){
            //slow to walk
            if(blendZ>maximumWalkVelocity){
                blendZ-=Time.deltaTime * deceleration;
            }else if(blendZ<maximumWalkVelocity){
                blendZ+=Time.deltaTime * deceleration;
            }
            //right
            if(blendX>maximumWalkVelocity){
                blendX-=Time.deltaTime * deceleration;
            }else if(blendX<maximumWalkVelocity && blendX > 0.0f){
                blendX+=Time.deltaTime * deceleration;
            }
            //left
            if(blendX<-maximumWalkVelocity){
                blendX+=Time.deltaTime * deceleration;
            }else if(blendX>-maximumWalkVelocity && blendX < 0.0f){
                 blendX-=Time.deltaTime * deceleration;
            }

            // turn left
            if((leftPress||turning < -0.3f) && (blendX > -0.5) ){
                blendX -= Time.deltaTime * acceleration;
            }
            // turn right
            if((rightPress||turning > 0.3f) && (blendX < 0.5) ){
                blendX += Time.deltaTime * acceleration;
            }
            //Deceleration left/right
            if((!leftPress||(turning>-0.3f&&turning<0.0f)) && (blendX < 0.0f)){
                blendX += Time.deltaTime * deceleration;
            }
            if((!rightPress||(turning<0.3f&&turning>0.0f)) && (blendX > 0.0f)){
                blendX -= Time.deltaTime * deceleration;
            }

            // Set velocity on the x axis to zero
            if((!leftPress||(turning>-0.3&&turning<0.0)) && (!rightPress||(turning<0.3&&turning>0.0)) && blendX != 0.0f && (blendX > -0.05f && blendX < 0.05f)){
                blendX = 0.0f;
            }
        }
        // jump
        if(animator.GetBool("isJump") == true){
            animator.SetBool("isJump",false);
            
        }
        if(jumpPress || jumpOrSlide > 0.3){
                animator.SetBool("isJump",false);
        }
        if((jumpPress || jumpOrSlide > 0.3 ) && animator.GetBool("isJump") == false){
            animator.SetBool("isJump",true);
            jumpPress =  false;
            
        }

        // slide
        animator.SetBool("isSlide",false);
        if((slidePress|| jumpOrSlide < -0.3)){
            animator.SetBool("isSlide",false);
        }
        if(animator.GetBool("isSlide") == true){
            animator.SetBool("isSlide",false);
        }
        if(slidePress || jumpOrSlide < -0.3){
                animator.SetBool("isSlide",true);
        }
        if((slidePress|| jumpOrSlide < -0.3) && animator.GetBool("isSlide") == false){
            animator.SetBool("isSlide",true);
            slidePress = false;
        }
        
        
        
        
        
        

        animator.SetFloat("BlendZ",blendZ);
        animator.SetFloat("BlendX",blendX);
        
    }
}

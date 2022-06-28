using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    float blendZ = 0.0f;
    float blendX = 0.0f;
    public float acceleration = 2.0f;
    public float deceleration =2.0f;
    //public float maximumWalkVelocity = 0.5f;
    public float maximumRunVelocity = 2.0f;
    // Start is called before the first frame update
    public bool obstacleHit;
    void Start()
    {
        animator = GetComponent<Animator>();
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

        if(hit){
            animator.SetBool("obstacleHit",true);
        }else if(!hit){
            animator.SetBool("obstacleHit",false);
        }
        

        float currentMaxVelocity = maximumRunVelocity;
        // start walking to running

        if(blendZ < currentMaxVelocity ){
            blendZ += Time.deltaTime * acceleration;
        }
        // turn left
        if(leftPress && (blendX > -currentMaxVelocity) ){
            blendX -= Time.deltaTime * acceleration;
        }
        // turn right
        if(rightPress && (blendX < currentMaxVelocity) ){
            blendX += Time.deltaTime * acceleration;
        }
        // jump
        if(animator.GetBool("isJump") == true){
            animator.SetBool("isJump",false);
            
        }
        if(jumpPress){
                animator.SetBool("isJump",false);
            }
        if(jumpPress && animator.GetBool("isJump") == false){
            animator.SetBool("isJump",true);
            jumpPress =  false;
            //animator.SetBool("isJump",false);
        }

        // slide
        if(animator.GetBool("isSlide") == true){
            animator.SetBool("isSlide",false);
        }
        if(slidePress && animator.GetBool("isSlide") == false){
            animator.SetBool("isSlide",true);
            slidePress = false;
            //animator.SetBool("isSlide",false);
        }
        //Deceleration left/right
        if(!leftPress && (blendX < 0.0f)){
            blendX += Time.deltaTime * deceleration;
        }
        if(!rightPress && (blendX > 0.0f)){
            blendX -= Time.deltaTime * deceleration;
        }

        // Set velocity on the x axis to zero
        if(!leftPress && !rightPress && blendX != 0.0f && (blendX > -0.05f && blendX < 0.05f)){
            blendX = 0.0f;
        }

        // lock forward, else decelerate to the maximum walk velocity
        if(blendZ > currentMaxVelocity){
            blendZ = currentMaxVelocity;
        }
        if(obstacleHit && obstacleHit && blendZ > currentMaxVelocity){
            blendZ -= Time.deltaTime * deceleration;
            if(blendZ > currentMaxVelocity && blendZ < (currentMaxVelocity - 0.05f)){
                blendZ = currentMaxVelocity;
            }
        }

        // lock left, else decelerate to the maximum walk velocity
        if(leftPress && blendZ < -currentMaxVelocity){
            blendZ = -currentMaxVelocity;
        }
        if(leftPress && obstacleHit && blendZ < -currentMaxVelocity){
            blendZ -= Time.deltaTime * deceleration;
            if(blendZ < -currentMaxVelocity && blendZ > (-currentMaxVelocity - 0.05f)){
                blendZ = -currentMaxVelocity;
            }
        }

        // lock right, else decelerate to the maximum walk velocity
        if(rightPress && blendZ > currentMaxVelocity){
            blendZ = currentMaxVelocity;
        }
        if(rightPress && obstacleHit && blendZ > currentMaxVelocity){
            blendZ -= Time.deltaTime * deceleration;
            if(blendZ > currentMaxVelocity && blendZ < (currentMaxVelocity - 0.05f)){
                blendZ = currentMaxVelocity;
            }
        }

        animator.SetFloat("BlendZ",blendZ);
        animator.SetFloat("BlendX",blendX);
        
    }
}

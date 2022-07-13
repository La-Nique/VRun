using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Credit to iHeartGameDev on Youtube for the blendX/blendZ implementation which
// related to his methodology in the Animator for the character and wolf
// https://www.youtube.com/watch?v=-FhvQDqmgmU&list=PLwyUzJb_FNeTQwyGujWRLqnfKpV-cj-eO
public class AlienAnimationStateController : MonoBehaviour
{
    Animator animator;
    public float blendZ = 0.0f;
    public float blendX = 0.0f;
    public float acceleration = 2.0f;
    public float deceleration =2.0f;
    public float maximumWalkVelocity = 0.5f;
    public float maximumRunVelocity = 2.0f;
    //public float crippleCount = 0.0f;
    //public bool obstacleHit;
    //public bool whileHit;
    private CharacterController alienCharacterController;
    public bool startGame = false;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        //animator.SetBool("obstacleHit",false);
        //obstacleHit = animator.GetBool("obstacleHit");
        alienCharacterController = GetComponent<CharacterController>();
        
    }

    bool gameHasEnded = false;

    public float restartDelay = 1f;

    public void Failed(){
        if(gameHasEnded == false){
            gameHasEnded = true;
            Debug.Log("YOU DIED. GAME OVER.");
            // Restart game.
            SceneManager.LoadScene(SceneManager.GetSceneByName("Failed Screen").buildIndex +2);
        }
        
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
        float speed = 2.0f;
        float turning = Input.acceleration.x;
        float jumpOrSlide = Input.acceleration.y;
        if(startGame == true){

            Vector3 charPosition = transform.position;
            if(charPosition.y < -10){
                Failed();
            } 


            //Move Character
            alienCharacterController.SimpleMove(new Vector3(0f,0f,0f));
            alienCharacterController.Move(transform.forward * blendZ * speed * 2 * Time.deltaTime);
            if(blendX < 0.0f){
                transform.position = new Vector3(transform.position.z, 0,0);
                alienCharacterController.Move(transform.position * blendX * Time.deltaTime * 0.03f);
                
            }
            if(blendX > 0.0f){
                transform.position = new Vector3(transform.position.z, 0,0);
                alienCharacterController.Move(transform.position * blendX * Time.deltaTime * 0.03f);
                
            }
            if(blendX != 0){
                transform.Rotate(new Vector3(0f, blendX*2, 0f));
            }
            
            /*

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

            */

            float currentMaxVelocity = runPress ? maximumRunVelocity : maximumWalkVelocity;
            
            //accelerometer
            
                if(blendZ < maximumRunVelocity ){
                    blendZ += Time.deltaTime * acceleration;
                }
                // turn left
                if((turning <-0.2f && turning >-1f) && (blendX > -2.0f) ){
                    if(blendX > 0){
                        blendX = 0;
                    }
                    blendX -= Time.deltaTime * 0.5f;
                }
                // center stop turning left
                if((turning >-0.2f && turning <0f) && blendX<0.0f){
                    blendX = 0f;
                    //blendX += Time.deltaTime * 1f;
                }
                //right
                if((turning > 0.2f && turning < 1f) && (blendX < 2f)){
                    if(blendX < 0){
                        blendX = 0;
                    }
                    blendX += Time.deltaTime * 0.5f;
                }
                //center stop turning right
                if((turning < 0.2f && turning > 0f) && (blendX > 0f)){
                    blendX = 0f;
                }
                // Set velocity on the x axis to zero
                if((turning >-0.2f && turning <0f) && (turning < 0.2f && turning > 0f) && blendX != 0.0f && (blendX > -0.05f && blendX < 0.05f)){
                    blendX = 0.0f;
                }
            
            //accelerometer
            
            // w a s d + space
            
            if(blendZ < maximumRunVelocity ){
                    blendZ += Time.deltaTime * acceleration;
                }
                // turn left
                if((leftPress||(turning > -0.8f && turning < 0.0f) ) && (blendX > -2) ){
                    blendX -= Time.deltaTime * acceleration;
                }
                
                // turn right
                if((rightPress||turning > 0.3f) && (blendX < 2) ){
                    blendX += Time.deltaTime * acceleration;
                }
                
                //Deceleration left/right
                if((!leftPress||(turning<-1f && turning > -0.8f)) && (blendX < 0)){
                    blendX += Time.deltaTime * deceleration;
                }
                
                if((!rightPress||(turning<0.3f&&turning>0.0f)) && (blendX > 0.0f)){
                    blendX -= Time.deltaTime * deceleration;
                }
                
                
                // Set velocity on the x axis to zero
                if((!leftPress||(turning>-0.3&&turning<0.0)) && (!rightPress||(turning<0.3&&turning>0.0)) && blendX != 0.0f && (blendX > -0.05f && blendX < 0.05f)){
                    blendX = 0.0f;
                }
            
            // w a s d + space
            
            /*
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
            */
            
            // jump
            if(animator.GetBool("isJump") == true){
                animator.SetBool("isJump",false);
                
            }
            if(/*jumpPress ||*/ (jumpOrSlide > -0.9 && jumpOrSlide < 0.5) ){
                    animator.SetBool("isJump",false);
            }
            if(((/*jumpPress ||*/ (jumpOrSlide > -0.9 && jumpOrSlide < 0.5))   && animator.GetBool("isJump") == false)){
                animator.SetBool("isJump",true);
                jumpPress =  false;
                
            }

            /*
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
            
            */
            
            
            
            

            animator.SetFloat("BlendZ",blendZ);
            animator.SetFloat("BlendX",blendX);
        }
    }
}

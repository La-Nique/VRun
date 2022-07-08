using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCharAnimationStateController : MonoBehaviour
{
    Animator animator;
    float blend = 0.0f;
    //private float latestDirectionChangeTime;
    //private readonly float directionChangeTime = 3f;
    private float characterVelocity = 0.5f;
    private Vector3 movementDirection;
    private Vector3 movementPerSecond;
    private AlienAnimationStateController animationStateController;
    bool didAttack = false;

    /////////
    /*
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float moveDistance = 1.5f;
    private float gravityValue = -9.81f;
    */
    //public float speed = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animationStateController = FindObjectOfType(typeof(AlienAnimationStateController)) as AlienAnimationStateController;
        //latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();
    }

    void calcuateNewMovementVector(){
     //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
     movementDirection = new Vector3(0.0f, 0.0f,-1.5f).normalized;
     movementPerSecond = movementDirection * characterVelocity;
 }

    
    // Update is called once per frame
    void Update()
    {
        bool isAttack = animator.GetBool("isAttack");
        bool obstacleHit = animationStateController.obstacleHit;
        if(transform.position.z <= -1.5f){
            transform.position = new Vector3(0, 0,
            transform.position.z - (movementPerSecond.z * Time.deltaTime));
            
        }
        
        if(transform.position.z >=-2f){
            animator.SetBool("isAttack", true);
            
            didAttack = true;
        }
        if(didAttack && transform.position.z >= -3.7f){
            animator.SetBool("isAttack", false);
            transform.position = new Vector3(0, 0,
            transform.position.z + (movementPerSecond.z * Time.deltaTime));
        }

        
        
        //animator.SetBool("isAttack", false);
        
        /*
        if(obstacleHit){
            transform.position = new Vector3(0.0f, 0.0f,-1.5f);
            
            
            float curPos = -3.9f;
            if(curPos < -1.5f){
                transform.position = new Vector3(0.0f, 0.0f,curPos + 0.7f);
                //animator.transform.position(0,0,curPos + 0.7);
            }
            animator.SetBool("isAttack",true);
            if(curPos > -3.9){
                transform.position = new Vector3(0.0f, 0.0f,curPos - 0.7f);
                //animator.transform.position(0,0,curPos - 0.7);
            }
            animator.SetBool("isAttack",false);
        }

        */
        blend = 1.0f;
        animator.SetFloat("Blend",blend);

    }
}

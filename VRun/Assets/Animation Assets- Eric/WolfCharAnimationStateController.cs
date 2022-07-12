using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCharAnimationStateController : MonoBehaviour
{
    Animator animator;
    float blend = 0.0f;
    //private float latestDirectionChangeTime;
    //private readonly float directionChangeTime = 3f;
    //private float characterVelocity = 0.5f;
    private Vector3 movementDirection;
    private Vector3 movementPerSecond;
    public AlienAnimationStateController animationStateController;
    //bool didAttack = false;

    public Transform charPosition;
    public float distance = -5f;
    //public float offset = 2.7f;
    public float delay = 0.03f;

    private CharacterController wolfController;
    public AudioSource source;





    //public Transform charPosition;
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
        wolfController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        
    }


    
    // Update is called once per frame
    void Update()
    {
        
        if(animationStateController.startGame == false){
            distance = 4;
            source.mute = true;
        }else if(distance > -4 && animationStateController.startGame == true){
            //source.unmute();
            source.mute = false;
            distance--;
        }
        bool isAttack = animator.GetBool("isAttack");

        Vector3 follow = charPosition.position - charPosition.forward * distance ;
        transform.position +=(follow - transform.position) * delay;
        if(animationStateController.blendX != 0){
            transform.Rotate(new Vector3(0f, animationStateController.blendX, 0f));
        }
        transform.LookAt(charPosition.transform);


        
        

        //bool obstacleHit = animationStateController.obstacleHit;
        /*
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
        didAttack = false;

        */
        
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

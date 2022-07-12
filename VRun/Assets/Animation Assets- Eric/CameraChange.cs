using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    //public Camera[] cameras = GetAllCameras();
    //GetAllCameras(Camera[] cameras);
    //Camera cam1 = GameObject.Find("MainCamera").GetComponent<Camera>();
    //Camera cam2 = GameObject.Find("Camera2").GetComponent<Camera>();
    // Start is called before the first frame update
    private AlienAnimationStateController alienChar;
    public GameObject start;
    public GameObject mountainCam;
    public GameObject startCam;

    void Start()
    {
        startCam.SetActive(false);
        mountainCam.SetActive(true);
        alienChar = start.GetComponent<AlienAnimationStateController>();
        StartCoroutine(waiter());
       
        //startCharMovement();
    }

    IEnumerator waiter()
    {
        // Wait for 12 seconds
        yield return new WaitForSecondsRealtime(12);
        mountainCam.SetActive(false); 
        startCam.SetActive(true);
        alienChar.startGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startCharMovement()
    {
       
    }
    
}

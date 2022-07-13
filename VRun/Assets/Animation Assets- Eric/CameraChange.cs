using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
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

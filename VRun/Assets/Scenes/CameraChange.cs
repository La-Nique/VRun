using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    //public Camera[] cameras = GetAllCameras();
    //GetAllCameras(Camera[] cameras);
    Camera cam1 = GameObject.Find("MainCamera").GetComponent<Camera>();
    Camera cam2 = GameObject.Find("Camera2").GetComponent<Camera>();
    private int currentCameraIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentCameraIndex = 0;
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(true);
        StartCoroutine(waiter());
        cam2.gameObject.SetActive(false);
        cam1.gameObject.SetActive(true);
        
    }
    IEnumerator waiter()
        {
            
            //Wait for 4 seconds
            yield return new WaitForSecondsRealtime(4);
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}

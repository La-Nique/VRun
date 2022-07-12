using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrackMars : MonoBehaviour
{
    public Transform charPosition;
    //public float distance = 1.0f;
    public float offset = 20f;
    public float delay = 0.01f;
    public float distance = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 follow = charPosition.position - charPosition.forward * distance;
        follow.y += offset;
        transform.position +=(follow - transform.position) * delay;
        transform.LookAt(charPosition.transform);
    }
}

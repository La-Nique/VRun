using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Credit to James Brady on Youtube for the algorithm below
// https://www.youtube.com/watch?v=517eJql_zd4&t=373s&ab_channel=JamesBrady

public class CharacterTracking : MonoBehaviour
{
    public Transform charPosition;
    public float distance = 1f;
    public float offset = 3f;
    public float delay = 0.02f;
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

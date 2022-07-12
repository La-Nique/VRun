using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTracking : MonoBehaviour
{
    public Transform charPosition;
    public float distance = 1f;
    public float offset = 3f;
    public float delay = 0.02f;
    /*
    public float distance = 1;
    public float offset = 2f;
    public float delay = 0.04f;
    */
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

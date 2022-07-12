using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTerrainController : MonoBehaviour
{
    public AlienAnimationStateController AlienController;
    // Start is called before the first frame update
    void Start()
    {
        float sidePositionX = AlienController.blendZ;
        float forwardPositionZ = AlienController.blendX;
    }

    // Update is called once per frame
    void Update()
    {
        float sidePositionX = AlienController.blendZ;
        float forwardPositionZ = AlienController.blendX;

        transform.position = new Vector3(0, 0,
            transform.position.z - (forwardPositionZ * Time.deltaTime));
        transform.position = new Vector3(transform.position.x - (sidePositionX * Time.deltaTime), 0,0);

    }
}

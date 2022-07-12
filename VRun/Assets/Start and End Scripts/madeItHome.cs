using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class madeItHome : MonoBehaviour
{
    // Alien Ship drag onto another object. Make alien ship a child of another object...
    
    // Within a certain distance
    // 3D distance formula (x,y,z) or 2D (x,z)
    // range of these coordinates around the ship 
    // go to end screen.
    // if (x,y) character position then go to end screen.

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 charPosition = GameObject.FindGameObjectWithTag("CharacterScene2").transform.position;
        Vector3 shipPosition = transform.position;
        float distance = Mathf.Sqrt(((shipPosition.x - charPosition.x)* (shipPosition.x - charPosition.x)) + 
                                ((shipPosition.y - charPosition.y)* (shipPosition.y - charPosition.y)) +
                                ((shipPosition.z - charPosition.z)* (shipPosition.z - charPosition.z)));
        if(distance < 200f){
            SceneManager.LoadScene(SceneManager.GetSceneByName("WonScreen_Mars").buildIndex+6);
        }
    }
}

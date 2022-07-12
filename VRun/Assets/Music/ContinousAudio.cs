using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// https://www.youtube.com/watch?v=ha6U8jHl9ak
// https://www.youtube.com/watch?v=1BMJFgK68IU

public class ContinousAudio : MonoBehaviour
{
    public static ContinousAudio instance;
 
    void Awake()
    {
        // if (instance != null)
        //     Destroy(gameObject);
        // else
        // {
        //     instance = this;
        //     DontDestroyOnLoad(this.gameObject);
        // }
    }
    
   void Update()
    {
        // // Check which scene we are on 
        // if (SceneManager.GetActiveScene().name == "VRun_")
        //     ContinousAudio.instance.GetComponent<AudioSource>().Play();
    }
}

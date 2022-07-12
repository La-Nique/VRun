using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinousAudio : MonoBehaviour
{
    public static ContinousAudio instance;
 
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    
   void Update()
    {
        // Check which scene we are on 
        if (SceneManager.GetActiveScene().name == "VRun_")
            ContinousAudio.instance.GetComponent<AudioSource>().Play();
    }
}

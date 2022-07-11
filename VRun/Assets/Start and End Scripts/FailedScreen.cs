using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// https://stackoverflow.com/questions/30056471/how-to-make-the-script-wait-sleep-in-a-simple-way-in-unity
public class FailedScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
    }
    IEnumerator waiter()
        {
            
            //Wait for 4 seconds
            yield return new WaitForSecondsRealtime(4);
            SceneManager.LoadScene(SceneManager.GetSceneByName("VRun_").buildIndex +1);
        }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WonScreen_Mars : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        // Wait for 4 seconds
        yield return new WaitForSecondsRealtime(4);
        // Returns to beginning of game
        SceneManager.LoadScene(SceneManager.GetSceneByName("VRun_").buildIndex +1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

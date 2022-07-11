using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailedScreen_Mars : MonoBehaviour
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
        // Restarts Mars scene
        SceneManager.LoadScene(SceneManager.GetSceneByName("VRun_Mars").buildIndex +4);
    }

    // Update is called once per frame <--- "just an action every frame."
    void Update()
    {

    }
}

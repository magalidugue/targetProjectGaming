using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Debug.Log("load scene : " + sceneName);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}

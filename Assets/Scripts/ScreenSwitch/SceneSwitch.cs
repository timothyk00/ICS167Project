using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public void Scene1()
    {
        SceneManager.LoadScene("Main");
    }

    public void endScene()
    {
        SceneManager.LoadScene("Victory");
    }
    public void startScene()
    {
        SceneManager.LoadScene("StartScreen");
    }
}

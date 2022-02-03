using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Cleon Doan Timothy Kwon
public class SceneSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public void Scene1() //Loads level1 when function called
    {
        SceneManager.LoadScene("Main"); //change to level1
    }

    public void endScene() //Loads ending scene when function called
    {
        SceneManager.LoadScene("Victory");
    }
    public void startScene() //Loads start scene when function called
    {
        SceneManager.LoadScene("StartScreen");
    }
}

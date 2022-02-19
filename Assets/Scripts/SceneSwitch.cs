using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Cleon Doan Timothy Kwon

public class SceneSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public void Scene1Single() //Loads level1 when function called
    {
        SceneManager.LoadScene("Level 1"); //change to level1
    }

    public void Scene1Multi() 
    {
        GameManager.GManager.SwapToMulti();
        SceneManager.LoadScene("Level 1"); 
    }

    public void endScene() //Loads ending scene when function called
    {
        SceneManager.LoadScene("Victory");
    }
    public void startScene() //Loads start scene when function called
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}

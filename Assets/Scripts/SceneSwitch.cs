using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//Cleon Doan Timothy Kwon

public class SceneSwitch : MonoBehaviour
{
    private bool _paused = false;
    public Canvas _escapeMenu = null;
    public GameObject objectiveC;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _escapeMenu != null)
        {
            if (_paused) // if menu already enabled
                ToggleEscMenu(false);
            else
                ToggleEscMenu(true);
        }
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (allEnemies.Length== 0)
        {
        objectiveC.GetComponent<TMP_Text>().text = "Current Objective:\n Reach the green checkpoint\n to the north!";
        }
        else
        {
        objectiveC.GetComponent<TMP_Text>().text = "Current Objective:\n Defeat all the enemies!\n Enemies Remaining: "+(allEnemies.Length);
        }
    }

    // Start is called before the first frame update
    public void Scene1Single() //Loads level1 when function called
    {
        GameManager.GManager.SwapToSingle();
        SceneManager.LoadScene("Level 1"); //change to level1
    }

    public void Scene1Multi() 
    {
        GameManager.GManager.SwapToMulti();
        SceneManager.LoadScene("Level 1"); 
    }

    public void EndScene() //Loads ending scene when function called
    {
        SceneManager.LoadScene("Victory");
    }
    public void StartScene() //Loads start scene when function called
    {
        ToggleEscMenu(false);
        SceneManager.LoadScene("StartScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToggleEscMenu(bool enabled)
    {
        Time.timeScale = enabled ? 0 : 1;
        _escapeMenu.enabled = enabled;
        _paused = enabled;
    }
}

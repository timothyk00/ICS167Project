using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Timothy Kwon
public class GameManager : MonoBehaviour
{

    public GameObject _goal;
    public GameObject _player;

    void Start()
    {
        
    }

    void Update()
    {
        CheckGoal();
        CheckPlayerAlive();
    }

    private void CheckGoal()
    {
        //temp way of seeing if player gets to goal
        if (_player.transform.position.x > 50)
            EndScene();
    }

    private void CheckPlayerAlive()
    {
        if (!_player.activeSelf)
            EndScene();
    }

    public void EndScene() //Loads ending scene when function called
    {
        SceneManager.LoadScene("Victory");
    }


}

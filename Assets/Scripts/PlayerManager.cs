using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Timothy Kwon
public class PlayerManager : MonoBehaviour
{
    private GameObject _goal;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _helperPrefab;

    private int _spawnOffset = 5;

    private void Awake()
    {
        if (GameManager.GManager.IsSinglePlayer())
        {
            Instantiate(_playerPrefab, new Vector3(-40, .5f, 0), Quaternion.Euler(new Vector3(0, 90, 0)));
            Instantiate(_helperPrefab, new Vector3(-40, 2, 3), Quaternion.Euler(new Vector3(0, 90, 0)));
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject pp = Instantiate(_playerPrefab, new Vector3(-40, .5f, _spawnOffset * i), Quaternion.Euler(new Vector3(0, 90, 0)));
                pp.GetComponent<PlayerMovementController>()._playerNum = 1 + i;
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        CheckPlayersAlive();
    }

    private void CheckPlayersAlive()
    {
        if (GameManager.GManager.GetPlayers().Length == 0)
        {
            EndScene();
        }
    }

    private void EndScene() //Loads ending scene when function called
    {
        SceneManager.LoadScene("Victory");
    }

}

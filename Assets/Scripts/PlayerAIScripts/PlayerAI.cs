using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerAI : MonoBehaviour
{
    private GameObject _player;

    private enum PLAYER_STATE
    {
        Follow,
        Attack
    }

    private PLAYER_STATE _playerState;

    void Start()
    {
        
    }

    
    void Update()
    {
        switch(_playerState)
        {
            case PLAYER_STATE.Follow:
                break;

            case PLAYER_STATE.Attack:
                break;
        }
    }
}

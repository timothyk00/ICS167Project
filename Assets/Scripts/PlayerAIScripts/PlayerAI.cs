using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


// Kevin Luu
public class PlayerAI : MonoBehaviour
{
    private NavMeshAgent _playerAI;
    private GameObject _player;

    private int _health;
    private Slider _healthSlider;

    private GameObject[] _enemies;

    // Player States
    private enum PLAYER_STATE
    {
        Follow,
        Attack,
        Evade,
    }

    private PLAYER_STATE _playerState;

    void Start()
    {
        // Find player to follow in 1 Player mode
        _player = GameManager.GManager.GetPlayers()[0];
        // Find enemies
        _enemies = GetEnemies();
    }

    
    void Update()
    {
        switch(_playerState)
        {
            case PLAYER_STATE.Follow:
                Follow();
                if (CanSeeEnemy())
                {
                    _playerState = PLAYER_STATE.Attack;
                }
                break;

            case PLAYER_STATE.Attack:
                Attack();
                if (!CanSeeEnemy())
                {
                    _playerState = PLAYER_STATE.Follow;
                }
                break;
        }
    }

    // Follows Player
    void Follow()
    {
        _playerAI.SetDestination(_player.transform.position);
    }

    private GameObject[] GetEnemies()
    {
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return _enemies;
    }


    bool CanSeeEnemy()
    {
        // Looks for Enemies in sight and within a certain distance
        RaycastHit raycastInfo;
        Vector3 rayToTarget = _player.transform.position - this.transform.position;

        // Perform a raycast to determine if there's anything between the AI and the enemies
        if (Physics.Raycast(this.transform.position, rayToTarget, out raycastInfo))
        {
            //WRONG I NEED TO FIX TO FIND ALL ENEMIES
            if (raycastInfo.transform.gameObject.tag == "Enemy" && Vector3.Distance(this.transform.position, _player.transform.position) < 10)
                return true;
        }
        return false;
    }

    // If enemy is in range, AI attacks using element
    void Attack()
    {
        
    }
}

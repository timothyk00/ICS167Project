using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

//Kevin Luu
public class FleeEnemy : Enemy
{
    public FleeEnemy()
    {
        _health = 10;
        _attack = 0;
    }

    void Start()
    {
        _healthSlider = this.GetComponentInChildren<Slider>();
        _healthSlider.maxValue = _health;

        _enemy = this.GetComponent<NavMeshAgent>();
        _enemy.speed = 4.5f;
        _enemy.acceleration = 10f;
    }

    void Update()
    {
        _player = GetClosestPlayer();
        if (_player)
        {
            _playerMove = _player.GetComponent<PlayerMovementController>();

            if (!PlayerInRange())
            {
                Wander();
            }
            else
            {
                Evade();
            }
        }
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

//Kevin Luu
public class FireEnemy : ShootingEnemy
{
    private enum FIREENEMY_STATE
    {
        Wander,
        Attack
    }

    private FIREENEMY_STATE _fireEnemyState;
    
    public FireEnemy()
    {
        _health = 10;
    }

    void Start()
    {
        _healthSlider = this.GetComponentInChildren<Slider>();
        _healthSlider.maxValue = _health;

        _enemy = this.GetComponent<NavMeshAgent>();
        _enemy.speed = 3.5f;
        _enemy.acceleration = 8f;

        _AIweapons.Add(_myFactory.GetAbility("fire"));
        _player = GetClosestPlayer();
        _destructable = false;
    }

    void Update()
    {
        switch(_fireEnemyState)
        {
            case FIREENEMY_STATE.Wander:
                Wander();
                if (CanSeePlayer(10))
                {
                    _fireEnemyState = FIREENEMY_STATE.Attack;
                }
                break;
            
            case FIREENEMY_STATE.Attack:
                ShootAttack();
                if (!CanSeePlayer(10))
                {
                    _fireEnemyState = FIREENEMY_STATE.Wander;
                }
                break;

        }
    }
    
}
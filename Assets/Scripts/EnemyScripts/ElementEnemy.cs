using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

//Kevin Luu
public class ElementEnemy : ShootingEnemy
{
    private enum ELEMENTENEMY_STATE
    {
        Wander,
        Attack
    }

    private ELEMENTENEMY_STATE _elementEnemyState;
    
    void Update()
    {
        _player = GetClosestPlayer();
        switch(_elementEnemyState)
        {
            case ELEMENTENEMY_STATE.Wander:
                Wander();
                if (CanSeePlayer(10))
                {
                    _elementEnemyState = ELEMENTENEMY_STATE.Attack;
                }
                break;
            
            case ELEMENTENEMY_STATE.Attack:
                ShootAttack(_reloadTime);
                if (!CanSeePlayer(10))
                {
                    _elementEnemyState = ELEMENTENEMY_STATE.Wander;
                }
                break;

        }
    }
    
}
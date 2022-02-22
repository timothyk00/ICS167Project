using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class SlowEnemy : Enemy
{

    void Start()
    {
        _health = 30;
        _attack = 20;
        _enemy = this.GetComponent<NavMeshAgent>();
        _enemy.speed = 2.5f;
        _enemy.acceleration = 8f;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class SlowEnemy : Enemy
{
    private int _health = 30;
    private int _attack = 20;

    void Start()
    {
        _enemy = this.GetComponent<NavMeshAgent>();
        _enemy.speed = 2.5f;
        _enemy.acceleration = 8f;
    }
}
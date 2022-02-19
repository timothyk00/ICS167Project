using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class FastEnemy : Enemy
{
    private int _health = 10;
    private int _attack = 10;

    void Start()
    {
        _enemy = this.GetComponent<NavMeshAgent>();
        _enemy.speed = 4.5f;
        _enemy.acceleration = 10f;
    }
}
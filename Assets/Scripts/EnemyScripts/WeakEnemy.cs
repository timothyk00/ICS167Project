using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class WeakEnemy : Enemy
{
    private int _health = 10;
    private int _attack = 5;

    void Start()
    {
        _enemy = this.GetComponent<NavMeshAgent>();
        _enemy.speed = 4f;
        _enemy.acceleration = 8f;
    }
}
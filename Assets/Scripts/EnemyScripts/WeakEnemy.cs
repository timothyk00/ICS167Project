using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class WeakEnemy : Enemy
{
    void Start()
    {
        _health = 10;
        _attack = 5;
        _enemy = this.GetComponent<NavMeshAgent>();
        _enemy.speed = 4f;
        _enemy.acceleration = 8f;
    }
}
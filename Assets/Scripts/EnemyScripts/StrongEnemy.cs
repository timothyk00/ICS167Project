using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class StrongEnemy : Enemy
{
    void Start()
    {
        _health = 10;
        _attack = 20;
        _enemy = this.GetComponent<NavMeshAgent>();
        _enemy.speed = 3f;
        _enemy.acceleration = 6f;
    }
}
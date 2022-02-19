using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class StrongEnemy : Enemy
{
    private int _health = 10;
    private int _attack = 20;
    void Start()
    {
        _enemy = this.GetComponent<NavMeshAgent>();
        _enemy.speed = 3f;
        _enemy.acceleration = 6f;
    }
}
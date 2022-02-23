using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class StrongEnemy : Enemy
{
    StrongEnemy()
    {
        _attack = 20;
    }

    void Start()
    {
        _healthSlider = this.GetComponentInChildren<Slider>();
        _healthSlider.maxValue = _health;

        _enemy = this.GetComponent<NavMeshAgent>();
        _enemy.speed = 3f;
        _enemy.acceleration = 6f;
    }
}
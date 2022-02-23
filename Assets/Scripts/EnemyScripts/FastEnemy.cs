using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

//Kevin Luu
public class FastEnemy : Enemy
{
    public FastEnemy()
    {
        _health = 10;
        _attack = 10;
    }

    void Start()
    {
        _healthSlider = this.GetComponentInChildren<Slider>();
        _healthSlider.maxValue = _health;

        _enemy = this.GetComponent<NavMeshAgent>();
        _enemy.speed = 4.5f;
        _enemy.acceleration = 10f;
    }
}
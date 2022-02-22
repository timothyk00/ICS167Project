using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class FastEnemy : Enemy
{
    void Start()
    {
        _health = 10;

        _healthSlider = this.GetComponentInChildren<Slider>();
        _healthSlider.maxValue = _health;

        _enemy = this.GetComponent<NavMeshAgent>();
        _enemy.speed = 4.5f;
        _enemy.acceleration = 10f;
    }
}
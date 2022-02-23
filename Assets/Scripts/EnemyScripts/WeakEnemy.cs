using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

//Kevin Luu
public class WeakEnemy : Enemy
{

    public WeakEnemy()
    {
        _health = 10;
        _attack = 5;
    }
    

    void Start()
    {
        _healthSlider = this.GetComponentInChildren<Slider>();
        _healthSlider.maxValue = _health;

        _enemy = this.GetComponent<NavMeshAgent>();
        _enemy.speed = 4f;
        _enemy.acceleration = 8f;
    }
}
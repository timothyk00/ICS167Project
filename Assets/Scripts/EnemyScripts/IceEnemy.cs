using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

//Kevin Luu
public class IceEnemy : ElementEnemy
{
    
    public IceEnemy()
    {
        _health = 10;
    }

    void Start()
    {
        _healthSlider = this.GetComponentInChildren<Slider>();
        _healthSlider.maxValue = _health;

        _enemy = this.GetComponent<NavMeshAgent>();
        _enemy.speed = 3.5f;
        _enemy.acceleration = 8f;

        _AIweapons.Add(_myFactory.GetAbility("ice"));
        _player = GetClosestPlayer();
        _destructable = false;
    }
}
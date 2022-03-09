using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using ElementFactory; //include using element factory

//Kevin Luu
//_AIWeapons[0].useAbility(this.transform.position,this.transform.forward); if player is near use this
// reduce selfD -=1
// update():
// if selfD == 0:
// Destroy();

public class ShootingEnemy : Enemy
{
    
    private int selfD = 5; 
    private List<Ability> _AIweapons = new List<Ability>();  //weapons inventory
    private AbilityFactory myFactory = new AbilityFactory(); //element factory 
    public ShootingEnemy()
    {
        _health = 100000000;
        _attack = 5;
    }
    

    void Start()
    {
        _healthSlider = this.GetComponentInChildren<Slider>();
        _healthSlider.maxValue = _health;
        _AIweapons.Add(myFactory.GetAbility("ice")); //calls the elementfactory to receive weapon 
        //ice electric fire earth 
        _enemy = this.GetComponent<NavMeshAgent>();
        _enemy.speed = 4f;
        _enemy.acceleration = 8f;
    }
}
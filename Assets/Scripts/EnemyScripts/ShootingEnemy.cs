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
    //Self Destruct counter
    private int _selfD = 5; 
    private List<Ability> _AIweapons = new List<Ability>();  //weapons inventory
    private AbilityFactory _myFactory = new AbilityFactory(); //element factory 
    
    private bool _reloading = false;

    private enum SHOOTENEMY_STATE
    {
        Idle,
        Attack
    }

    private SHOOTENEMY_STATE _shootEnemyState;

    public ShootingEnemy()
    {
        _health = 100000000;
    }
    

    void Start()
    {
        _healthSlider = this.GetComponentInChildren<Slider>();
        _healthSlider.maxValue = _health;

        _AIweapons.Add(_myFactory.GetAbility("ice")); //calls the elementfactory to receive weapon 
        _enemy = this.GetComponent<NavMeshAgent>();
        _player = GetClosestPlayer();
    }

    void Update()
    {
        switch(_shootEnemyState)
        {
            case SHOOTENEMY_STATE.Idle:
            if (CanSeePlayer())
            {
                Debug.Log("Switch to Attack");
                _shootEnemyState = SHOOTENEMY_STATE.Attack;
            }
            break;
            
            case SHOOTENEMY_STATE.Attack:
            Attack();
            Debug.Log("Attacking");
            _selfD -= 1;
            if (_selfD == 0)
            {
                Destroy(this);
            }
            if (!CanSeePlayer())
            {
                Debug.Log("Switch to Idle");
                _shootEnemyState = SHOOTENEMY_STATE.Idle;
            }
            break;
        }
    }

    void Attack()
    {
        _enemy.transform.LookAt(_player.transform.position);
        
        if (!_reloading)
        {
            _AIweapons[0].useAbility(this.transform.position,this.transform.forward);
            _reloading = true;
            StartCoroutine(Reload());
        }

    }

    private IEnumerator Reload(){
          yield return new WaitForSeconds(3);   //or however long you want the reload time to be
          _reloading = false;
    }
}
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
    private int _selfD = 20; 
    protected List<Ability> _AIweapons = new List<Ability>();  //weapons inventory
    protected AbilityFactory _myFactory = new AbilityFactory(); //element factory 
    
    protected bool _reloading = false;
    protected bool _destructable = true;

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
        //_healthSlider = this.GetComponentInChildren<Slider>();
        //_healthSlider.maxValue = _health;

        _AIweapons.Add(_myFactory.GetAbility("ice")); //calls the elementfactory to receive weapon 
        _enemy = this.GetComponent<NavMeshAgent>();
        _player = GetClosestPlayer();
    }

    void Update()
    {
        switch(_shootEnemyState)
        {
            case SHOOTENEMY_STATE.Idle:
            if (CanSeePlayer(40))
            {
                _shootEnemyState = SHOOTENEMY_STATE.Attack;
            }
            break;
            
            case SHOOTENEMY_STATE.Attack:
            ShootAttack();
            if (!CanSeePlayer(40))
            {
                _shootEnemyState = SHOOTENEMY_STATE.Idle;
            }
            break;
        }
    }

    protected virtual void ShootAttack()
    {
        _enemy.velocity = Vector3.zero;
        _enemy.transform.LookAt(_player.transform.position);
        
        if (!_reloading)
        {
            _AIweapons[0].useAbility(this.transform.position,this.transform.forward);
            _reloading = true;
            StartCoroutine(Reload());

            _selfD -= 1;
            if (_selfD == 0 && _destructable)
            {
                Destroy(_enemy.gameObject);
            }
        }
    }

    protected virtual IEnumerator Reload(){
        yield return new WaitForSeconds(3);   //or however long you want the reload time to be
        _reloading = false;
    }
}